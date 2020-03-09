using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Record_Manager
{
    class FileHandler
    {
        public const int author_cap = 30;
        public const int title_cap = 200;
        public const int journal_cap = 100;
        public const int year_cap = 5;
        public const int abstract_cap = 1500;
        public const int keyword_cap = 25;
        public const int found_in_cap = 80;
        public const int rec_length = author_cap + title_cap + journal_cap + year_cap + abstract_cap;

        public static int rec_count;
        public static int keyword_count;

        public const string formatted_filepath = "Formated_Data.txt";
        public const string author_filepath = "Index_Author.txt";
        public const string title_filepath = "Index_Title.txt";
        public const string keyword_filepath = "Index_Keyword.txt";

        public static void CreateFormattedFiles(string source_filename)
        {
            int rec_num = 0;
            StreamReader reader = new StreamReader(File.Open(source_filename, FileMode.Open));

            string author = "";
            string title = "";
            string journal = "";
            string pub_year = "";
            string abstract_ = "";

            string line = reader.ReadLine();

            while (!reader.EndOfStream)
            {

                if (line.Contains("Authors: "))
                {
                    rec_num += 1;
                    author = line.Substring(10);
                }
                else if (line.Contains("Title: "))
                {
                    title = line.Substring(8);
                    String nextline = reader.ReadLine();
                    if (!nextline.Contains("Pub.Date: "))
                        title += nextline;

                    // trim additional info after end of title -> (.)
                    for (int i = 0; i < title.Length; i++)
                    {
                        if (title[i] == '.' || title[i] == '?')
                        {
                            title = title.Substring(0, i);
                            break;
                        }

                    }

                }
                else if (line.Contains("FOUND IN: "))
                {
                    journal = line.Substring(11);
                }
                else if (line.Contains("Pub.Date: "))
                {
                    pub_year = line.Substring(11);
                }
                else if (line.Contains("Abstract: "))
                {
                    abstract_ = line.Substring(11);
                    String nextline = reader.ReadLine();
                    while (!nextline.Contains("Pub.Type: "))
                    {
                        abstract_ += nextline;
                        nextline = reader.ReadLine();
                    }
                    AddRecordToFormatedFile(author, title, journal, pub_year, abstract_, rec_num - 1);
                }
                line = reader.ReadLine();
            }
            reader.Dispose();
            rec_count = rec_num;
            CreateIndex("Formated_Data.txt", title_filepath, rec_num, "title");
            CreateIndex("Formated_Data.txt", author_filepath, rec_num, "author");
            CreateIndex("Formated_Data.txt", keyword_filepath, rec_num, "keyword");
        }

        private static void AddRecordToFormatedFile(String author_, String title_, String journal_, String year_, String abstract_, int index)
        {

            BinaryWriter bw = new BinaryWriter(File.Open(formatted_filepath, FileMode.OpenOrCreate));
            bw.BaseStream.Position = index * rec_length;

            WriteToFile(bw, author_, author_cap);

            WriteToFile(bw, title_, title_cap);

            WriteToFile(bw, journal_, journal_cap);

            WriteToFile(bw, year_, year_cap);

            WriteToFile(bw, abstract_, abstract_cap);

            bw.Dispose();

        }

        public static void CreateIndex(string formatted_file, string index_filename, int rec_count_, string filetype)
        {
            Dictionary<string, ArrayList> the_dictionary = new Dictionary<string, ArrayList>();

            using (BinaryReader br = new BinaryReader(File.Open(formatted_file, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(index_filename, FileMode.Create)))
                {

                    // loop through formated records, get the title from each record, get each word from each title, index word into keyword index file

                    for (int i = 0; i < rec_count_; i++)
                    {
                        int rec_id = i + 1;


                        if (filetype == "title")
                        {
                            string title = "";
                            // looping through title
                            br.BaseStream.Position = (i * rec_length) + author_cap;
                            for (int j = 0; j < title_cap; j++)
                            {
                                char c;
                                try { c = br.ReadChar(); }
                                catch (System.IO.EndOfStreamException) { break; } // end of reader file stream


                                if (c == '~')
                                {
                                    AddToDictionary(the_dictionary, title, rec_id);
                                    break;
                                }
                                else
                                    title += c;

                            }
                        }
                        else if (filetype == "author")
                        {
                            br.BaseStream.Position = (i * rec_length);

                            string name = "";
                            for (int j = 0; j < author_cap; j++)
                            {
                                char c;
                                try { c = br.ReadChar(); }
                                catch (System.IO.EndOfStreamException) { break; } // end of reader file stream


                                if (c == '~')
                                {
                                    AddToDictionary(the_dictionary, name, rec_id);
                                    break;
                                }
                                else
                                    name += c;

                            }
                        }
                        else if (filetype == "keyword")
                        {
                            string word = "";
                            // looping through title
                            br.BaseStream.Position = (i * rec_length) + author_cap;
                            for (int j = 0; j < title_cap; j++)
                            {
                                char c;
                                try { c = br.ReadChar(); }
                                catch (System.IO.EndOfStreamException) { break; } // end of reader file stream

                                if (Char.IsLetter(c))
                                {
                                    word += c;
                                }
                                else if (c == ' ' && word != "")
                                {
                                    AddToDictionary(the_dictionary, word, rec_id);
                                    word = "";

                                }
                                else if (c == '~')
                                {
                                    AddToDictionary(the_dictionary, word, rec_id);
                                    break;
                                }

                            }

                            // looping through abstract
                            br.BaseStream.Position = (i * rec_length) + author_cap + title_cap + journal_cap + year_cap;
                            word = "";
                            for (int j = 0; j < abstract_cap; j++)
                            {
                                char c;
                                try { c = br.ReadChar(); }
                                catch (System.IO.EndOfStreamException) { break; } // end of reader file stream

                                if (Char.IsLetter(c))
                                {
                                    word += c;
                                }
                                else if (c == ' ' && word != "")
                                {

                                    AddToDictionary(the_dictionary, word, rec_id);
                                    word = "";


                                }
                                else if (c == '~')
                                {
                                    AddToDictionary(the_dictionary, word, rec_id);
                                    break;
                                }

                            }
                        }
                    }

                    // Acquire keys and sort them.
                    var list = the_dictionary.Keys.ToList();
                    list.Sort();
                    if (filetype == "keyword")
                        keyword_count = list.Count;

                    foreach (var key in list)
                    {
                        if (filetype == "title")
                            WriteToFile(bw, key, title_cap);
                        else if (filetype == "author")
                            WriteToFile(bw, key, author_cap);
                        else if (filetype == "keyword")
                            WriteToFile(bw, key, keyword_cap);
                        string num_list = "";
                        // for each num inside the word's 'found in'
                        foreach (int num in the_dictionary[key])
                            num_list += num + ",";

                        WriteToFile(bw, num_list, found_in_cap);

                        num_list = "";
                    }

                }

            }

        }

        private static void AddToDictionary(Dictionary<string, ArrayList> dict_, string word_, int rec_num)
        {
            word_ = word_.ToLower();
            try
            {
                dict_.Add(word_, new ArrayList());
                dict_[word_].Add(rec_num);
            }
            catch (ArgumentException)
            {
                // throws if word already exist in dictionary
                // adds current record # to the word's "found in" list
                if (!dict_[word_].Contains(rec_num))
                    dict_[word_].Add(rec_num);

            }
        }

        private static void WriteToFile(BinaryWriter bw, string data, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (i < data.Length)
                    bw.Write(data[i]);
                else
                    bw.Write('~');
            }
        }

    }

}




