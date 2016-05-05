using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JeevesFiler
{

    //struct rep. a file to possibly rename
    public struct fileToRename
    {
        public string longPath;
        public string fileName;
        public string renameLong;
        public string renameShort;
        public string justFile;
        public string justExtension;
        public Boolean renameFlag;
        public DateTime fileCreation;

        public fileToRename(string longP = "", string fileN = "", string rLong = "", string rShort = "", Boolean rFlag = true, DateTime cTime = new DateTime())
        {
            longPath = longP;
            fileName = fileN;
            renameLong = rLong;
            renameShort = rShort;
            renameFlag = rFlag;
            fileCreation = cTime;

            if((DateTime.Compare(cTime, new DateTime()) == 0) && (longP != ""))
            {
                FileInfo temp = new FileInfo(longP);
                fileCreation = temp.CreationTime;
            }

            if (fileN != "")
            {
                justExtension = fileN.Substring(fileN.LastIndexOf(".") + 1);
                justFile = fileN.Substring(0, fileN.Length - justExtension.Length - 1);
            }
            else
            {
                justExtension = "";
                justFile = "";
            }

        }
    }

    //short enum to improve readability for sorting comparison method
    public enum sortBy
    {
        LexAsc = 1,
        SizeAsc = 2,
        TimeAsc = 3,
        LexDsc = 4,
        SizeDsc = 5,
        TimeDsc =6
    };

    //main form
    public partial class JeevesForm : Form
    {

        private string folderPath;
        private string[] files;
        private fileToRename[] sortedFiles, partialFiles;
        private delegate int compDelegate(fileToRename arg1, fileToRename arg2);
        private compDelegate compMethod;
        private Boolean sortedBoxInit = false;
        private List<string> extensionTokenList = new List<string>();
        private List<string> yearTokenList = new List<string>();
        private static int recursionCt = 0;

        //set default values for comboboxes on form after init
        public JeevesForm()
        {
            InitializeComponent();
            PrefixDateCmbo.SelectedIndex = 0;
            SuffixDateCmbo.SelectedIndex = 0;
        }

        #region Click and Double Click Event Handlers for Buttons and ListBoxes

        //**return handler for browseFolderDialog retrieving folder path for files to rename
        private void browseFolder_Click(object sender, EventArgs e)
        {
            if(browseFolderDialog.ShowDialog() == DialogResult.OK) {
                folderPath = browseFolderDialog.SelectedPath;
                pathLabel.Text = folderPath;
                grabFiles();
            }
        }

        //thread delegate to expand stack size
        public void threadRecursion()
        {
            //Console.WriteLine("Childthread");
            try
            {
                insertionSort(ref sortedFiles);
            }

            catch (ThreadAbortException e)
            {
                //Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                //Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }

        //**preview button click, check if there are filters that need to be applied,
        //sort, create the renamed files list, then display them
        private void previewFilters_Click(object sender, EventArgs e)
        {

            if (sortedFiles != null)
            {
                SortedBox.Items.Clear();
                //re grab sortedFiles array for now, since filters manip. sortedFiles
                initSortedFiles();
                applyFilters();
                determineMethod(sortByRadioChecked());

                //creating a thread for the insertion sort to increase stack size
                ThreadStart childrec = new ThreadStart(threadRecursion);
                Thread recurseThread = new Thread(childrec, 4194304);

                if (GroupByExtRadio.Checked)
                {
                    previewFilters.Text = "sorting...";
                    extensionGroupSort(ref sortedFiles);
                    previewFilters.Text = "preview";
                }
                else if (GroupByYrRadio.Checked)
                {
                    previewFilters.Text = "sorting...";
                    yearGroupSort(ref sortedFiles);
                    previewFilters.Text = "preview";
                }
                else
                {
                    previewFilters.Text = "sorting...";
                    recurseThread.Start();
                    recurseThread.Join();
                    recurseThread.Abort();
                    previewFilters.Text = "preview";
                }

                createFileRenames();

                int pad;
                string display;
                foreach (fileToRename f in sortedFiles)
                {
                    display = "";

                    if (GroupByYrRadio.Checked) { display += "( " + f.fileCreation.Year.ToString() + " ) "; }

                    if(GroupByExtRadio.Checked) { display += "( " + f.justExtension + " ) "; }

                    if (IgnorePrefixChk.Checked && IgnorePrefixTextB.Text != "" && int.TryParse(IgnorePrefixTextB.Text, out pad))
                    {
                        if (pad < f.justFile.Length && pad > 0) { display += "{" + f.fileName.Substring(0, pad) + "} " + f.fileName.Substring(pad) + " => " + f.renameShort; }
                        else { display += f.fileName + " => " + f.renameShort; }
                    }
                    else
                    {
                        display += f.fileName + " => " + f.renameShort;
                    }

                    SortedBox.Items.Add(display, true);
                }
                //set the flag saying that the sortedBox has been initialized
                sortedBoxInit = true;
            }

        }

        //**rename files click button handler
        private void commitSort_Click(object sender, EventArgs e)
        {
            if (!sortedBoxInit)
            {
                MessageBox.Show("Please preview the renaming schema before changing the file names.");
            }
            else if (!checkDuplicateRenames())
            {
                MessageBox.Show("Duplicate renamed files exist, please double check your renaming scheme and click preview before proceeding.");
            }
            else
            {
                if (MessageBox.Show("Rename Files?", "Confirm Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (checkOpenFiles()) { renameFiles(); }
                }
            }

            RenameProgress.Value = 0;
        }

        //**exit program button click handler
        private void ExitOut_Click(object sender, EventArgs e)
        {
            //nifty kill code
            System.Windows.Forms.Application.Exit();
        }

        //**sortedBox doubleclick handler to try to open file w/default app
        private void SortedBox_DoubleClick(object sender, EventArgs e)
        {
            if (sortedBoxInit) { System.Diagnostics.Process.Start(@sortedFiles[SortedBox.SelectedIndex].longPath); }
        }

        #endregion

        #region Sort and Comparison Functions

        //**assign anon function [compMethod] to appropriate sort method, based on passed in int [based on form radioboxes]
        private void determineMethod(int method)
        {
            //switch to choose what comparison method to use
            switch (method)
            {
                case 1:
                    compMethod = LexCompareAsc;
                    break;
                case 2:
                    compMethod = SizeCompareAsc;
                    break;
                case 3:
                    compMethod = TimeCompareAsc;
                    break;
                case 4:
                    compMethod = LexCompareDsc;
                    break;
                case 5:
                    compMethod = SizeCompareDsc;
                    break;
                case 6:
                    compMethod = TimeCompareDsc;
                    break;
                default:
                    compMethod = LexCompareDsc;
                    break;
            }
        }

        //**InsertionSort, should change to quicksort should the array size get big
        private void insertionSort(ref fileToRename[] filesArray, int index = 0, int compare = -1)
        {

            recursionCt++;

            if (recursionCt > 14000)
            {
                recursionCt = 0;
                MessageBox.Show("Sorry, file list could not be completely sorted due to sorting and memory issues; please choose a smaller batch of files to rename.");
                return;
            }

            //exit condition, array should be sorted at this point
            if (index + 1 > filesArray.Length)
            {
                recursionCt = 0;
                return;
            }

            //index now guaranteed to be in array

            //compare previous element if element to compare equals index
            if (compare == index)
            {
                insertionSort(ref filesArray, index, compare - 1);
                return;
            }

            fileToRename holder;

            //check that compare is still in array bounds
            //compare less than zero: element should be put at beginning of array
            if (compare < 0)
            {
                //check beginning of array index condition
                if (index == 0)
                {
                    compare = index;
                    insertionSort(ref filesArray, index + 1, compare);
                }
                else
                {
                    //else, remove and insert element to front of array
                    holder = filesArray[index];
                    filesRemoveAt(ref filesArray, index);
                    filesInsertAt(ref filesArray, holder, 0);
                    //iterate index, reset compare to one element before index, dictioary sort once more
                    compare = index;
                    insertionSort(ref filesArray, index + 1, compare);
                }
                return;
            }

            //compMethod should be determined beforehand, based on radiobutton selected
            //compare >= 0, run a string comparison and either iterate compare element left (-1), or insert element into sorted position and iterate index
            int CompareResult, pad;
            if (IgnorePrefixChk.Checked && IgnorePrefixTextB.Text != "" && int.TryParse(IgnorePrefixTextB.Text, out pad))
            {
                string indexJF = filesArray[index].justFile;
                string compareJF = filesArray[compare].justFile;
                if (pad < indexJF.Length && pad > 0) { filesArray[index].justFile = indexJF.Substring(pad); }
                if (pad < compareJF.Length && pad > 0) { filesArray[compare].justFile = compareJF.Substring(pad); }
                CompareResult = compMethod(filesArray[index], filesArray[compare]);
                filesArray[index].justFile = indexJF;
                filesArray[compare].justFile = compareJF;
            }
            else { CompareResult = compMethod(filesArray[index], filesArray[compare]); }

            //case: stringCompareResult < 0, element at index precedes element being compared; iterate compared element left in array (-1), compare again
            if (CompareResult < 0)
            {
                insertionSort(ref filesArray, index, compare - 1);
            }

            //case: stringCompareResult = 0, element name is the same, either the extensions are different or there is an array copy error
            //if the extensions are the same, then throw a debug messagebox
            //in both cases, place the index element before the compared element and increment index / reset compared element
            else if (CompareResult == 0)
            {

                //check to see that we aren't inserting and removing at the same location, if we are, the element after the location
                //to insert at filesArray(compare + 1) will be the same element as the compared index element (index)
                if (String.Compare(filesArray[index].fileName, filesArray[compare + 1].fileName) == 0)
                {
                    //continue down the length of the array
                    compare = index;
                    insertionSort(ref filesArray, index + 1, compare);
                    return;
                }

                holder = filesArray[index];
                //insert first so I don't have to check if compare < 0
                filesInsertAt(ref filesArray, holder, compare);
                //index + 1 should always exist since we inserted first
                filesRemoveAt(ref filesArray, index + 1);
                //iterate index, reset compare to one element before index, dictioary sort once more
                compare = index;
                insertionSort(ref filesArray, index + 1, compare);
            }

            //case: stringCompareResult > 0, the element at index follows the compared element in sort order
            //insert index element after compared element, remove duplicate index element, dictionarySort with incremented index / reset compared element
            else if (CompareResult > 0)
            {
                //check to see that we aren't inserting and removing at the same location, if we are, the element after the location
                //to insert at filesArray(compare + 1) will be the same element as the compared index element (index)
                if (String.Compare(filesArray[index].fileName, filesArray[compare + 1].fileName) == 0)
                {
                    //continue down the length of the array
                    compare = index;
                    insertionSort(ref filesArray, index + 1, compare);
                    return;
                }

                holder = filesArray[index];
                //insert first, one elemnt after the compared element since the index element follows the compared element
                filesInsertAt(ref filesArray, holder, compare + 1);
                //index + 1 should always exist since we inserted first
                filesRemoveAt(ref filesArray, index + 1);
                //iterate index, reset compare to one element before index, dictioary sort once more
                compare = index;
                insertionSort(ref filesArray, index + 1, compare);
            }

            return;
        }

        //**lexigraphical comparison
        //arg1 before arg2, return < 0
        //arg1 = arg2, return 0
        //arg1 after arg2, return > 0
        private int LexCompareAsc(fileToRename arg1, fileToRename arg2)
        {
            return String.Compare(arg1.justFile, arg2.justFile);
        }
        //**descending
        private int LexCompareDsc(fileToRename arg1, fileToRename arg2)
        {
            return String.Compare(arg2.justFile, arg1.justFile);
        }

        //**file size comparison
        //arg1 < arg2, return < 0
        //arg1 = arg2, return 0
        //arg1 > arg2, return > 0
        private int SizeCompareAsc(fileToRename arg1, fileToRename arg2)
        {
            FileInfo file1 = new FileInfo(arg1.longPath);
            FileInfo file2 = new FileInfo(arg2.longPath);

            if (file1.Length < file2.Length) { return -1; }
            else if (file1.Length == file2.Length) { return 0; }
            else { return 1; }
        }
        //**descending
        private int SizeCompareDsc(fileToRename arg1, fileToRename arg2)
        {
            FileInfo file1 = new FileInfo(arg1.longPath);
            FileInfo file2 = new FileInfo(arg2.longPath);

            if (file1.Length > file2.Length) { return -1; }
            else if (file1.Length == file2.Length) { return 0; }
            else { return 1; }
        }

        //**file timestamp comparison
        //arg1 created before arg2, return < 0
        //arg1 created same time as arg2, return 0
        //arg1 created after arg2, return > 0
        private int TimeCompareAsc(fileToRename arg1, fileToRename arg2)
        {
            return DateTime.Compare(arg1.fileCreation, arg2.fileCreation);
        }
        //**descending
        private int TimeCompareDsc(fileToRename arg1, fileToRename arg2)
        {
            return DateTime.Compare(arg2.fileCreation, arg1.fileCreation);
        }

        //thread delegate to expand stack size using parts of the sorted files array
        public void threadRecursionPartial()
        {
            //Console.WriteLine("Childthread");
            try
            {
                insertionSort(ref partialFiles);
            }

            catch (ThreadAbortException e)
            {
                //Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                //Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }

        //**function to handle grouping by extension then sorting
        //terribly inefficient, makes me wish I had used lists for everything
        private void extensionGroupSort(ref fileToRename[] files)
        {
            getExtensionList();

            fileToRename[] dummy = new fileToRename[files.Length];

            int i = 0;
            int j = 0;

            string[] temp;
            string extension;
            int extTokenCount;

            //for each token extension
            foreach (string token in extensionTokenList)
            {
                temp = token.Split(':');
                extension = temp[0];
                extTokenCount = int.Parse(temp[1]);

                fileToRename[] tempArray = new fileToRename[extTokenCount];

                //grab the files with the same extension
                foreach(fileToRename f in sortedFiles)
                {
                    if(string.Compare(f.justExtension, temp[0]) == 0)
                    {
                        tempArray[i] = new fileToRename(f.longPath, f.fileName, f.renameLong, f.renameShort, f.renameFlag, f.fileCreation);
                        i += 1;
                    }
                }

                i = 0;

                //creating a thread for the insertion sort to increase stack size
                ThreadStart childrec = new ThreadStart(threadRecursionPartial);
                Thread recurseThread = new Thread(childrec, 4194304);

                partialFiles = tempArray;

                //sort the files with the same extension
                recurseThread.Start();
                recurseThread.Join();
                recurseThread.Abort();
                //insertionSort(ref tempArray);

                tempArray = partialFiles;

                //add them to our final sorted array, works in order of extension token list
                foreach (fileToRename g in tempArray)
                {
                    dummy[j] = new fileToRename(g.longPath, g.fileName, g.renameLong, g.renameShort, g.renameFlag, g.fileCreation);
                    j += 1;
                }

                partialFiles = null;
            }

            //assign results
            files = dummy;
            dummy = null;

            return;
        }

        //**function to handle grouping by year then sorting
        //terribly inefficient, makes me wish I had used lists for everything
        private void yearGroupSort(ref fileToRename[] files)
        {
            getYearList();

            fileToRename[] dummy = new fileToRename[files.Length];

            int i = 0;
            int j = 0;

            string[] temp;
            string year;
            int yearCount;

            //for each year
            foreach (string token in yearTokenList)
            {
                temp = token.Split(':');
                year = temp[0];
                yearCount = int.Parse(temp[1]);

                fileToRename[] tempArray = new fileToRename[yearCount];

                //grab files with the same year
                foreach (fileToRename f in sortedFiles)
                {
                    if (string.Compare(f.fileCreation.Year.ToString(), temp[0]) == 0)
                    {
                        tempArray[i] = new fileToRename(f.longPath, f.fileName, f.renameLong, f.renameShort, f.renameFlag, f.fileCreation);
                        i += 1;
                    }
                }

                i = 0;

                //creating a thread for the insertion sort to increase stack size
                ThreadStart childrec = new ThreadStart(threadRecursionPartial);
                Thread recurseThread = new Thread(childrec, 4194304);

                partialFiles = tempArray;

                //sort the files with the same year
                recurseThread.Start();
                recurseThread.Join();
                recurseThread.Abort();
                //insertionSort(ref tempArray);

                tempArray = partialFiles;
                
                //and add them to the resulting sorted array
                foreach (fileToRename g in tempArray)
                {
                    dummy[j] = new fileToRename(g.longPath, g.fileName, g.renameLong, g.renameShort, g.renameFlag, g.fileCreation);
                    j += 1;
                }

                partialFiles = null;
            }

            //assign the results
            files = dummy;
            dummy = null;

            return;
        }

        #endregion

        #region JeevesForm GUI Functions

        //**form function to modify Gui side PrefixDate Checkbox, PrefixDate Combobox, PrefixDate TextBox
        private void PrefixDateChk_CheckedChanged(object sender, EventArgs e)
        {
            if (PrefixDateChk.Checked)
            {
                PrefixCounterChk.Checked = false;
                PrefixDateCmbo.Visible = true;
                PrefixDateCmbo.Enabled = true;
                PrefixTextB.Visible = false;
                PrefixTextB.Enabled = false;
            }
            else
            {
                PrefixDateCmbo.Visible = false;
                PrefixDateCmbo.Enabled = false;
                PrefixTextB.Visible = true;
                PrefixTextB.Enabled = true;
            }
        }

        //**event handler for PrefixCounter Checkbox to ensure that PrefixDate is not concurrently checked, manages display
        private void PrefixCounterChk_CheckedChanged(object sender, EventArgs e)
        {
            if (PrefixCounterChk.Checked)
            {
                PrefixDateChk.Checked = false;
                PrefixTextB.Enabled = false;
                PrefixDigitTextB.Enabled = true;
            }
            else
            {
                PrefixTextB.Enabled = true;
                PrefixDigitTextB.Enabled = false;
            }
        }

        //**event handler for SuffixDate Checkbox to ensure Suffix Counter isn't concurrently checked, manages display
        private void SuffixDateChk_CheckedChanged(object sender, EventArgs e)
        {
            if (SuffixDateChk.Checked)
            {
                SuffixCounterChk.Checked = false;
                SuffixDateCmbo.Visible = true;
                SuffixDateCmbo.Enabled = true;
                SuffixTextB.Visible = false;
                SuffixTextB.Enabled = false;
            }
            else
            {
                SuffixDateCmbo.Visible = false;
                SuffixDateCmbo.Enabled = false;
                SuffixTextB.Visible = true;
                SuffixTextB.Enabled = true;
            }
        }

        //**event handler for SuffixCounter Checkbox to manage SuffixDate controls
        private void SuffixCounterChk_CheckedChanged(object sender, EventArgs e)
        {
            if (SuffixCounterChk.Checked)
            {
                SuffixDateChk.Checked = false;
                SuffixTextB.Enabled = false;
                SuffixDigitTextB.Enabled = true;
            }
            else
            {
                SuffixTextB.Enabled = true;
                SuffixDigitTextB.Enabled = false;
            }
        }

        //**event handler for when an item in CheckedListBox [SortedBox] gets checked or unchecked
        private void SortedBox_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            //if the box has been initialized, react to changes to the user checking / unchecking items from it
            if (sortedBoxInit)
            {
                //if the checkbox is unchecked, it will be checked AFTER this event is handled
                sortedFiles[e.Index].renameFlag = (e.CurrentValue == CheckState.Unchecked);
                updateSortedBox(e.Index);
            }

        }

        //**function to reflect changes made to sortedFiles array to the GUI display of SortedBox (CheckedListBox)
        //may pass in index to update, if not passed, will update entire box
        private void updateSortedBox(int index = -1)
        {
            //check if there are items
            if(SortedBox.Items.Count < 1) { return; }

            createFileRenames();
            int pad;
            string display = "";

            if(index >= 0 && index < sortedFiles.Length)
            {
                if (GroupByYrRadio.Checked) { display += "( " + sortedFiles[index].fileCreation.Year.ToString() + " ) "; }

                if (GroupByExtRadio.Checked) { display += "( " + sortedFiles[index].justExtension + " ) "; }

                if (IgnorePrefixChk.Checked && IgnorePrefixTextB.Text != "" && int.TryParse(IgnorePrefixTextB.Text, out pad))
                {
                    if (pad < sortedFiles[index].justFile.Length && pad > 0) { display += "{" + sortedFiles[index].fileName.Substring(0, pad) + "} " + sortedFiles[index].fileName.Substring(pad) + " => " + sortedFiles[index].renameShort; }
                    else { display += sortedFiles[index].fileName + " => " + sortedFiles[index].renameShort; }
                }
                else
                {
                    display += sortedFiles[index].fileName + " => " + sortedFiles[index].renameShort;
                }

                SortedBox.Items[index] = display;
                return;
            }

            for (int i = 0; i < sortedFiles.Length; i++)
            {
                display = "";

                if(GroupByYrRadio.Checked) { display += "( " + sortedFiles[i].fileCreation.Year.ToString() + " ) "; }

                if (GroupByExtRadio.Checked) { display +="( " + sortedFiles[i].justExtension + " ) "; }

                if (IgnorePrefixChk.Checked && IgnorePrefixTextB.Text != "" && int.TryParse(IgnorePrefixTextB.Text, out pad))
                {
                    if (pad < sortedFiles[i].justFile.Length && pad > 0) { display += "{" + sortedFiles[i].fileName.Substring(0, pad) + "} " + sortedFiles[i].fileName.Substring(pad) + " => " + sortedFiles[i].renameShort; }
                    else { display += sortedFiles[i].fileName + " => " + sortedFiles[i].renameShort; }
                }
                else
                {
                    display += sortedFiles[i].fileName + " => " + sortedFiles[i].renameShort;
                }

                SortedBox.Items[i] = display;
            }

        }

        //**event handler to update the display of SortedBox if the date format of PrefixDate changes
        private void PrefixDateCmbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sortedBoxInit) { updateSortedBox(); }
        }

        //**event handler to update the display of SortedBox if the date format of SuffixDate changes
        private void SuffixDateCmbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sortedBoxInit) { updateSortedBox(); }
        }

        //**event handler to enable / disable the GUI of the Ignore Prefix TextBox based on its corresponding checkbox
        private void IgnorePrefixChk_CheckedChanged(object sender, EventArgs e)
        {
            if (IgnorePrefixChk.Checked) { IgnorePrefixTextB.Enabled = true; }
            else { IgnorePrefixTextB.Enabled = false; }
        }

        #endregion

        #region Functions to Filter Renaming Scope

        //**lex filters, add or remove functions here
        private void lexFilters()
        {
            string selectStart = LexFilterSelectStartTextB.Text;
            string selectEnd = LexFilterSelectEndTextB.Text;
            string excludeStart = LexFilterExcludeStartTextB.Text;
            string excludeEnd = LexFilterExcludeEndTextB.Text;

            if (selectStart != "" || selectEnd != "" || (excludeStart != "" && excludeEnd != ""))
            {
                //put array in lex order if we need to apply lex filters to it
                if (AscOrderRadio.Checked) { determineMethod((int)sortBy.LexAsc); }
                else { determineMethod((int)sortBy.LexDsc); }
                LexRadio.Checked = true;
                insertionSort(ref sortedFiles);

                if (selectStart != "" || selectEnd != "") { lexSelectFilter(selectStart, selectEnd); }
                if (excludeStart != "" && excludeEnd != "") { lexExcludeFilter(excludeStart, excludeEnd); }

            }
        }

        //**function to set fileToRename[] sortedFiles to the sub array within the bounds of start and end, lexicographically
        private void lexSelectFilter(string start, string end)
        {
            //LexFilterSelectStartTextB
            //LexFilterSelectEndTextB
            int startIndex = 0;
            int endIndex = sortedFiles.Length - 1;

            if (start != "")
            {
                while ((startIndex < sortedFiles.Length) && String.Compare(start, sortedFiles[startIndex].justFile) > 0)
                {
                    startIndex++;
                }
            }
            if (end != "")
            {
                while ((endIndex >= 0) && String.Compare(end, sortedFiles[endIndex].justFile) < 0)
                {
                    endIndex--;
                }
            }

            //catch the cases where the desired lex bounds are outside of the fileToRename[] array - message and return
            if (startIndex == sortedFiles.Length || endIndex < 0 || (startIndex > endIndex))
            {
                MessageBox.Show("Files listed are outside of desired filter selection bounds.");
                return;
            }

            //startIndex should be <= endIndex and both should be in the array, set sortedFiles to the subarray defined by them
            sortedFiles = fileSubArray(sortedFiles, startIndex, endIndex);
            return;
        }

        //**function to remove from fileToRename[] sortedFiles the sub array bound from start to end, lexicographically
        private void lexExcludeFilter(string start, string end)
        {
            //MessageBox.Show("lex exclude start: " + start + "; end: " + end);
            //LexFilterExcludeStartTextB
            //LexFilterExcludeEndTextB
            if (start == "" || end == "")
            {
                MessageBox.Show("Bad start or end argument given for lex exclusion filter.");
                return;
            }

            int startIndex = 0;
            int endIndex = sortedFiles.Length - 1;

            while ((startIndex < sortedFiles.Length) && String.Compare(start, sortedFiles[startIndex].justFile) > 0)
            {
                startIndex++;
            }

            while ((endIndex >= 0) && String.Compare(end, sortedFiles[endIndex].justFile) < 0)
            {
                endIndex--;
            }

            //MessageBox.Show("startIndex: " + startIndex + "; endIndex: " + endIndex);

            //catch the cases where the desired lex bounds are outside of the fileToRename[] array - message and return
            if (startIndex == sortedFiles.Length || endIndex < 0 || (startIndex > endIndex))
            {
                MessageBox.Show("Files listed are outside of desired exclusion selection bounds.");
                return;
            }

            //startIndex should be <= endIndex and both should be in the array, set sortedFiles to the subarray defined by them
            sortedFiles = fileRemoveSubArray(sortedFiles, startIndex, endIndex);

            //MessageBox.Show("sortedFiles length: " + sortedFiles.Length);
            return;
        }

        //function to return a new array that is a sub array of the fileToRename array passed to it, starting at index start
        //ending at index end, INCLUSIVE
        private fileToRename[] fileSubArray(fileToRename[] files, int start, int end)
        {
            int subArrayLength = end - start + 1;

            if (subArrayLength < 0)
            {
                MessageBox.Show("incorrect sub array size, start: " + start + "; end: " + end + ";");
                return null;
            }

            fileToRename[] dummy = new fileToRename[subArrayLength];

            for (int i = start, j = 0; i <= end; i++, j++)
            {
                dummy[j] = new fileToRename(files[i].longPath, files[i].fileName, files[i].renameLong, files[i].renameShort, files[i].renameFlag, files[i].fileCreation);
            }

            return dummy;
        }

        //function to return a new fileToRename array that removes a sub array from the original array passed to it, with the sub array to remove
        //starting at index start and ending at index end, INCLUSIVE
        private fileToRename[] fileRemoveSubArray(fileToRename[] files, int start, int end)
        {
            int subArrayLength = end - start + 1;

            if (subArrayLength < 0)
            {
                MessageBox.Show("incorrect sub array size to remove, start: " + start + "; end: " + end + ";");
                return null;
            }

            fileToRename[] dummy = new fileToRename[files.Length - subArrayLength];

            for (int i = 0, j = 0; i < files.Length; i++, j++)
            {
                //MessageBox.Show("sub array loop: start is at " + start + "; dummy j is at " + j + "; end is at " + end + "; and files i is at " + i);
                if (i < start || i > end)
                {
                    dummy[j] = new fileToRename(files[i].longPath, files[i].fileName, files[i].renameLong, files[i].renameShort, files[i].renameFlag, files[i].fileCreation);
                    //MessageBox.Show("dummy[" + j + "] = new fileToRename(" + files[i].longPath + ", " + files[i].fileName + ", " + files[i].renameLong + ", " + files[i].renameShort + ");");
                }
                else
                {
                    j -= 1;
                }
            }

            return dummy;
        }


        //**remove one fileToRename struct from the passed in fileToRename[] array
        private void filesRemoveAt(ref fileToRename[] files, int index)
        {
            fileToRename[] dummy = new fileToRename[files.Length - 1];

            //sanity check to make sure index to remove is in the array
            if (index < 0 || index >= files.Length)
            {
                MessageBox.Show("Index to remove out of bounds: " + index);
                return;
            }

            //i iterates through the old array
            //j iterates through the created array
            for (int i = 0, j = 0; i < files.Length; i++, j++)
            {

                if(i != index)
                {
                    if (j >= dummy.Length)
                    {
                        MessageBox.Show("out of bounds error for removing array element.");
                        return;
                    }

                    dummy[j] = new fileToRename(files[i].longPath, files[i].fileName, files[i].renameLong, files[i].renameShort, files[i].renameFlag, files[i].fileCreation);
                }
                else if (i == index)
                {
                    j -= 1;
                }
            }

            files = dummy;
        }

        //**insert one fileToRename struct into the passed fileToRename[] array
        private void filesInsertAt(ref fileToRename[] files, fileToRename insertElement, int insertIndex)
        {
            fileToRename[] dummy = new fileToRename[files.Length + 1];

            //quick sanity check on insertIndex to make sure it's not outside of the bounds of the new Array
            if (insertIndex < 0 || insertIndex >= dummy.Length)
            {
                MessageBox.Show("Index to insert at out of bounds.");
                return;
            }

            //i iterates through the old array
            //j iterates through the created array
            for (int i = 0, j = 0; j < dummy.Length; i++, j++)
            {
                if (j >= dummy.Length)
                {
                    MessageBox.Show("out of bounds error for inserting array element.");
                    return;
                }

                if (i != insertIndex)
                {
                    dummy[j] = new fileToRename(files[i].longPath, files[i].fileName, files[i].renameLong, files[i].renameShort, files[i].renameFlag, files[i].fileCreation);
                }
                else if (i == insertIndex)
                {
                    dummy[j] = new fileToRename(insertElement.longPath, insertElement.fileName, insertElement.renameLong, insertElement.renameShort, insertElement.renameFlag, insertElement.fileCreation);
                    j += 1;
                    //if statement to catch the case where compare is the last element to be added to the array
                    if(i < files.Length)
                    {
                        dummy[j] = new fileToRename(files[i].longPath, files[i].fileName, files[i].renameLong, files[i].renameShort, files[i].renameFlag, files[i].fileCreation);
                    }
                }
            }

            files = dummy;
        }

        #endregion

        #region Backend Init. / Helper Functions

        //**init array of custom struct rep. files to be renamed [sortedFiles]
        private void initSortedFiles()
        {
            //set the flag saying that the SortedBox display has not been init or re-init
            sortedBoxInit = false;
            sortedFiles = new fileToRename[files.Length];
            int i = 0;

            foreach (string filePath in files)
            {
                sortedFiles[i] = new fileToRename(filePath, filePath.Substring(folderPath.Length + 1));
                i++;
            }
        }

        //function to calculate the extensions list based on current sortedFiles array
        private void getExtensionList()
        {
            if(sortedFiles == null) { return; }

            extensionTokenList.Clear();
            int index;

            foreach (fileToRename f in sortedFiles)
            {
                string ext = f.justExtension;
                if (ext != "")
                {
                    index = extensionTokenList.FindIndex(token => token.Contains(ext + ":"));

                    if (index >= 0)
                    {
                        extensionTokenList[index] = ext + ":" + (int.Parse((extensionTokenList[index].Split(':'))[1]) + 1).ToString();
                        //MessageBox.Show(extensionTokenList[index]);
                    }
                    else { extensionTokenList.Add(ext + ":1"); }
                }
            }

            extensionTokenList = extensionTokenList.OrderBy(token => token).ToList();

            return;
        }

        //function to calculate the year token list based on current sortedFiles array
        private void getYearList()
        {
            if (sortedFiles == null) { return; }

            yearTokenList.Clear();
            int index;

            foreach (fileToRename f in sortedFiles)
            {

                string year = f.fileCreation.Year.ToString();

                if (year != "")
                {
                    index = yearTokenList.FindIndex(token => token.Contains(year + ":"));

                    if (index >= 0)
                    {
                        yearTokenList[index] = year + ":" + (int.Parse((yearTokenList[index].Split(':'))[1]) + 1).ToString();
                        //MessageBox.Show(extensionTokenList[index]);
                    }
                    else { yearTokenList.Add(year + ":1"); }
                }
            }

            yearTokenList = yearTokenList.OrderBy(token => token).ToList();

            return;
        }

        //**display unsorted files in listbox
        private void listUnsortedFiles()
        {
            UnsortedBox.Items.Clear();

            foreach (string f in files)
            {
                UnsortedBox.Items.Add(f.Substring(folderPath.Length + 1));
            }
        }

        //function to return an int value rep. comparison method to use in sorting, based on form radio buttons
        private int sortByRadioChecked()
        {
            int value = 0;
            if (LexRadio.Checked)
            {
                if (AscOrderRadio.Checked) { value = (int)sortBy.LexAsc; }
                else { value = (int)sortBy.LexDsc; }

            }
            if (SizeRadio.Checked)
            {
                if (AscOrderRadio.Checked) { value = (int)sortBy.SizeAsc; }
                else { value = (int)sortBy.SizeDsc; }
            }
            if (TimeRadio.Checked)
            {
                if (AscOrderRadio.Checked) { value = (int)sortBy.TimeAsc; }
                else { value = (int)sortBy.TimeDsc; }
            }
            return value;
        }

        //**function to apply all filters the filesToRename[] array
        private void applyFilters()
        {
            lexFilters();
            return;
        }

        //**attempt to retrieve files from file path [folderPath]
        private void grabFiles()
        {
            files = Directory.GetFiles(folderPath);
            if (files.Length > 0)
            {
                initSortedFiles();
                sortedBoxInit = true;
                listUnsortedFiles();
            }
            else {
                MessageBox.Show("No files found.");
            }
        }

        //function to create the renameLong and renameShort values for files rep. in the fileToRename[]
        private void createFileRenames()
        {
            string prefix = PrefixTextB.Text;
            string core = CoreTextB.Text;
            string suffix = SuffixTextB.Text;
            int prefixCounter = 0;
            int suffixCounter = 0;

            for (int i = 0; i < sortedFiles.Length; i++)
            {
                if (PrefixDateChk.Checked && sortedFiles[i].renameFlag)
                {
                    prefix = sortedFiles[i].fileCreation.ToString(PrefixDateCmbo.SelectedItem.ToString());
                }
                if (PrefixCounterChk.Checked && sortedFiles[i].renameFlag)
                {
                    prefix = prefixCounter.ToString("D" + PrefixDigitTextB.Text);
                    prefixCounter++;
                }

                if (SuffixDateChk.Checked && sortedFiles[i].renameFlag)
                {
                    suffix = sortedFiles[i].fileCreation.ToString(SuffixDateCmbo.SelectedItem.ToString());
                }
                if (SuffixCounterChk.Checked && sortedFiles[i].renameFlag)
                {
                    suffix = suffixCounter.ToString("D" + SuffixDigitTextB.Text);
                    suffixCounter++;
                }

                if(sortedFiles[i].renameFlag)
                {
                    sortedFiles[i].renameShort = prefix + core + suffix + "." + sortedFiles[i].justExtension;
                    sortedFiles[i].renameLong = folderPath + "\\" + prefix + core + suffix + "." + sortedFiles[i].justExtension;
                }
                else
                {
                    sortedFiles[i].renameShort = "";
                    sortedFiles[i].renameLong = "";
                }
                
            }

            return;
        }

        //save renaming commit from failing when it trys to overwrite an existing file halfway through the loop, my hero
        //this seems expensive
        private Boolean checkDuplicateRenames()
        {
            foreach(fileToRename f in sortedFiles)
            {
                if (f.renameFlag)
                {
                    if(f.renameShort == "" || f.renameLong == "") { return false; }
                    for(int i=0, j=0; i < sortedFiles.Length; i++)
                    {
                        if(sortedFiles[i].renameFlag && (f.renameLong == sortedFiles[i].renameLong)) { j += 1; }
                        if (j > 1) { return false; }
                    }
                }
            }

            return true;
        }

        //Bool function to check to make sure any files to rename aren't in use by another process,
        //return true if all files are not in use
        private Boolean checkOpenFiles()
        {
            double ct = sortedFiles.Length, i = 0;

            foreach(fileToRename f in sortedFiles)
            {
                FileInfo temp = new FileInfo(f.longPath);
                FileStream stream = null;
                i += 1;
                try
                {
                    stream = temp.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                }
                catch (IOException)
                {
                    MessageBox.Show("File " + f.fileName + " is currently in use. Please close all applications using this file and try again.");
                    return false;
                }
                finally
                {
                    if (stream != null) { stream.Close(); }
                    RenameProgress.Value = (int)Math.Floor(75 * (i / ct));
                }
            }

            return true;
        }

        //function to attempt to rename all files in sortedFiles to their determined rename convo
        private void renameFiles()
        {
            SortedBox.Items.Clear();

            double ct = sortedFiles.Length, i = 0;

            foreach (fileToRename f in sortedFiles)
            {
                i += 1;

                if (f.renameFlag && f.longPath != "" && f.renameLong != "")
                {
                    try
                    {
                        //MessageBox.Show(f.longPath + "=>" + f.renameLong);
                        System.IO.File.Move(f.longPath, f.renameLong);
                        SortedBox.Items.Add(f.fileName + " renamed to " + f.renameShort);
                        RenameProgress.Value = 75 + (int)Math.Floor(25 * (i / ct));
                    }
                    catch (Exception e)
                    {
                        SortedBox.Items.Add(f.fileName + " could not be renamed to " + f.renameShort + ": " + e.ToString());
                    }
                }
            }

            sortedBoxInit = false;
            UnsortedBox.Items.Clear();
            grabFiles();
        }

        #endregion

    }
}
