using NHunspell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Helpers
{
    public class SpellCheckHelper
    {        
        public string SpellCheck(string Text)
        {
            Hunspell hunspell = new Hunspell(System.Web.HttpContext.Current.Server.MapPath("~/Assets/SpellCheck/en_US.aff"), System.Web.HttpContext.Current.Server.MapPath("~/Assets/SpellCheck/en_US.dic"));            
        
        try
            {
                                         
                    
                        //// Do spell check and look for suggested word. only if text does NOT contain number
                        if (Text.text.Length >= 3) 
                        {
                            var containsNumber = Text.text.Any(char.IsDigit);
                            if (!containsNumber)
                            {
                                var Correct = hunspell.Spell(Text.text);
                                if (!Correct)
                                {
                                    List<string> suggestions = hunspell.Suggest(Text.text);
                                    foreach (string suggestion in suggestions.Take(1))
                                    {
                                       //// Do something with the Suggested word
										////// suggestion is the object that is corrected word
									   }
                                }
                            }

                            // check for Commas, Dashes, Periods right after Text
                            var lastLetter = Text.text.Substring(Text.text.Length - 1);
                            if ( (lastLetter == ",") || (lastLetter == ".") || (lastLetter == "-") )
                            {
                                var suggestion = Text.text.Remove(Text.text.Length - 1);
                             ////// Do something with word
							 }
                        }
                   
                }

                hunspell.Dispose();

                }
            catch (Exception ex)
            {
                      //hunspell.Dispose();
            }

            
            hunspell.Dispose();

            return "Success";
        }
        
    }
}