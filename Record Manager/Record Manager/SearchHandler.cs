using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record_Manager
{
    class SearchHandler
    {

        public static ArrayList BinarySearch(string search_type, int cap_size, BinaryReader br, string target, int right_)
        {

            int left = 0;
            int right = right_;

            int last_match_position = -1;

            while (left <= right)
            {
                int mid = left + ((right - left) / 2);

                // sets the position of the file reader
                br.BaseStream.Position = mid * (cap_size + FileHandler.found_in_cap);

                string word = GetWordFromFile(br, cap_size);

                int myOutput = string.Compare(word, target); // determines if a string is greater than or less than another string

                // last match is used for wildcard search
                if (word.Length >= target.Length && target == word.Substring(0, target.Length))
                    last_match_position = mid * (cap_size + FileHandler.found_in_cap);

                if (word == target)
                {
                    // move to found in section of record {1,2,3,...}
                    br.BaseStream.Position = (mid * (cap_size + FileHandler.found_in_cap)) + cap_size;
                    string num = "";
                    ArrayList found_in_list = new ArrayList();
                    for (int i = 0; i < FileHandler.found_in_cap; i++)
                    {
                        char c = br.ReadChar();
                        if (Char.IsDigit(c))
                            num += c;
                        else if (c == ',')
                        {
                            found_in_list.Add(Convert.ToInt32(num));
                            num = "";
                        }
                        else if (c == '~')
                            break;

                    }
                    // if search type is default or boolean, just return the search results
                    if (search_type != "Wildcard")
                        return found_in_list;
                    else // if wildcard, break out of while loop to start linear search
                        break;
                }
                else if (myOutput < 0) { left = mid + 1; }
                else { right = mid - 1; }

            }

            if (search_type == "Wildcard")
            {
                if (last_match_position != -1)
                {
                    int index = 0;
                    ArrayList found_in_list = new ArrayList();
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        // sets the position of the file reader
                        br.BaseStream.Position = last_match_position + (index * (cap_size + FileHandler.found_in_cap));

                        string word = GetWordFromFile(br, cap_size);

                        if (word.Length >= target.Length && target == word.Substring(0, target.Length))
                        {
                            // move to found in section of record {1,2,3,...}
                            br.BaseStream.Position = last_match_position + (index * (cap_size + FileHandler.found_in_cap)) + cap_size;
                            string num = "";
                            // loop through found in section, & read each character
                            for (int i = 0; i < FileHandler.found_in_cap; i++)
                            {
                                char c = br.ReadChar();
                                if (Char.IsDigit(c))
                                    num += c;
                                else if (c == ',')
                                {
                                    if (!found_in_list.Contains(Convert.ToInt32(num)))
                                        found_in_list.Add(Convert.ToInt32(num));
                                    num = "";
                                }
                                else if (c == '~')
                                    break;

                            }
                        }
                        else
                        {
                            // search target doesn't match with the found word, then just return what we have
                            return found_in_list;
                        }
                        index++;
                    }
                }

            }

            return null;

        }

        private static string GetWordFromFile(BinaryReader br, int num_of_characters_to_read)
        {
            string word = "";
            for (int i = 0; i < num_of_characters_to_read; i++)
            {
                char c;
                try
                {
                    c = br.ReadChar();
                }
                catch (System.IO.EndOfStreamException) //end of file
                {
                    break;
                }
                if (c != '~')
                    word += c;
                else
                    break;
            }

            return word;
        }

    }
}
