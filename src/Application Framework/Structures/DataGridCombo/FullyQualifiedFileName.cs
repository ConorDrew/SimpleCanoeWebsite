namespace FSM
{
    public class FullyQualifiedFileName
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        // This provides the fully qualified name of the file for persisting operations.
        public string Text = string.Empty;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private static string extractExtension(string text)
        {
            var folder = default(string);
            var name = default(string);
            var ext = default(string);
            splitText(text, ref folder, ref name, ref ext);
            return ext;
        }

        private static string extractFolder(string text)
        {
            var folder = default(string);
            var name = default(string);
            var ext = default(string);
            splitText(text, ref folder, ref name, ref ext);
            if ((folder ?? "") == @"\")
                folder = XmlPersister.DefaultFolder;
            return folder;
        }

        private static string extractFolderAndName(string text)
        {
            var folder = default(string);
            var name = default(string);
            var ext = default(string);
            splitText(text, ref folder, ref name, ref ext);
            if (folder.Length == 0)
                folder = XmlPersister.DefaultFolder;
            return folder + name;
        }

        private static string extractName(string text)
        {
            var folder = default(string);
            var name = default(string);
            var ext = default(string);
            splitText(text, ref folder, ref name, ref ext);
            return name;
        }

        private static string extractNameWithExt(string text)
        {
            var folder = default(string);
            var name = default(string);
            var ext = default(string);
            splitText(text, ref folder, ref name, ref ext);
            if (ext.Length > 0)
            {
                return name + "." + ext;
            }
            else
            {
                return name;
            }
        }

        private static void splitText(string toSplit, ref string folder, ref string name, ref string ext)

        {
            folder = string.Empty;
            name = string.Empty;
            ext = string.Empty;
            if (toSplit.Length > 0)
            {
                int pos = toSplit.LastIndexOf(@"\");
                if (pos > 0)
                {
                    folder = toSplit.Substring(0, pos);
                    name = toSplit.Substring(pos + 1);
                }
                else
                {
                    // there is no "\" in the file, so there is no folder
                    name = toSplit;
                }

                toSplit = name;
                if (toSplit.Length > 0)
                {
                    pos = toSplit.LastIndexOf(".");
                    if (pos > 0)
                    {
                        name = toSplit.Substring(0, pos);
                        ext = toSplit.Substring(pos + 1);
                    }
                }
            }

            if (!folder.EndsWith(@"\"))
            {
                folder += @"\";
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        // Provides a unique name of the object to the user with extension appended
        public string Extension
        {
            get
            {
                return extractExtension(Text);
            }
        }

        // Provides initial directory during open operations from a document
        // that HAS been saved (IsNew is False).  Also provides initial
        // directory when saving documents with a new name (Save As...)
        public string Folder
        {
            get
            {
                return extractFolder(Text);
            }

            set
            {
                if (!value.EndsWith(@"\"))
                    value += @"\";
                Text = value + NameAndExt;
            }
        }

        public string FolderAndName
        {
            get
            {
                return extractFolderAndName(Text);
            }
        }

        // Provides a unique name of the object to the user with extension appended
        public string Name
        {
            get
            {
                return extractName(Text);
            }
        }

        // Provides a unique name of the object to the user with extension appended
        public string NameAndExt
        {
            get
            {
                return extractNameWithExt(Text);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}