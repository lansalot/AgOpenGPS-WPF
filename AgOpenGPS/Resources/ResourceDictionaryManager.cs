using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using Wpf.Ui.Appearance;

namespace AgOpenGPS.Resources
{
    public class ResourceDictionaryManager
    {
        //
        // Summary:
        //     Namespace, e.g. the library the resource is being searched for.
        public string SearchNamespace { get; }

        public ResourceDictionaryManager(string searchNamespace)
        {
            SearchNamespace = searchNamespace;
        }

        //
        // Summary:
        //     Shows whether the application contains the System.Windows.ResourceDictionary.
        //
        // Parameters:
        //   resourceLookup:
        //     Any part of the resource name.
        //
        // Returns:
        //     false if it doesn't exist.
        public bool HasDictionary(string resourceLookup)
        {
            return GetDictionary(resourceLookup) != null;
        }

        //
        // Summary:
        //     Gets the System.Windows.ResourceDictionary if exists.
        //
        // Parameters:
        //   resourceLookup:
        //     Any part of the resource name.
        //
        // Returns:
        //     System.Windows.ResourceDictionary, null if it doesn't exist.
        public ResourceDictionary? GetDictionary(string resourceLookup)
        {
            Collection<ResourceDictionary> allDictionaries = GetAllDictionaries();
            if (allDictionaries.Count == 0)
            {
                return null;
            }

            resourceLookup = resourceLookup.ToLower().Trim();
            foreach (ResourceDictionary item in allDictionaries)
            {
                if (item?.Source != null)
                {
                    string text = item.Source.ToString().ToLower().Trim();
                    if (text.Contains(SearchNamespace) && text.Contains(resourceLookup))
                    {
                        return item;
                    }
                }

                foreach (ResourceDictionary mergedDictionary in item.MergedDictionaries)
                {
                    if (!(mergedDictionary?.Source == null))
                    {
                        string text = mergedDictionary.Source.ToString().ToLower().Trim();
                        if (text.Contains(SearchNamespace) && text.Contains(resourceLookup))
                        {
                            return mergedDictionary;
                        }
                    }
                }
            }

            return null;
        }

        //
        // Summary:
        //     Shows whether the application contains the System.Windows.ResourceDictionary.
        //
        // Parameters:
        //   resourceLookup:
        //     Any part of the resource name.
        //
        //   newResourceUri:
        //     A valid System.Uri for the replaced resource.
        public bool UpdateDictionary(string resourceLookup, Uri newResourceUri)
        {
            Collection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries.Count == 0)
            {
                return false;
            }

            if (newResourceUri == null)
            {
                return false;
            }

            resourceLookup = resourceLookup.ToLower().Trim();
            for (int i = 0; i < mergedDictionaries.Count; i++)
            {
                if (mergedDictionaries[i]?.Source != null)
                {
                    string text = mergedDictionaries[i].Source.ToString().ToLower().Trim();
                    if (text.Contains(resourceLookup))
                    {
                        mergedDictionaries[i] = new ResourceDictionary
                        {
                            Source = newResourceUri
                        };
                        return true;
                    }
                }

                for (int j = 0; j < mergedDictionaries[i].MergedDictionaries.Count; j++)
                {
                    if (!(mergedDictionaries[i].MergedDictionaries[j]?.Source == null))
                    {
                        string text = mergedDictionaries[i].MergedDictionaries[j].Source.ToString().ToLower().Trim();
                        if (text.Contains(resourceLookup))
                        {
                            mergedDictionaries[i].MergedDictionaries[j] = new ResourceDictionary
                            {
                                Source = newResourceUri
                            };
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private Collection<ResourceDictionary> GetAllDictionaries()
        {
            return Application.Current.Resources.MergedDictionaries;
        }
    }

    
}
