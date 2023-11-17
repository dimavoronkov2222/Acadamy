using System;
using System.Collections.ObjectModel;

public class SharedData
{
    private static SharedData instance = null;
    public ObservableCollection<string> ListBoxItems { get; private set; }
    private SharedData()
    {
        ListBoxItems = new ObservableCollection<string>();
    }
    public static SharedData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SharedData();
            }
            return instance;
        }
    }
}
