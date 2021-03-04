using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;

namespace treeView
{
    [AddINotifyPropertyChangedInterface]

    public class Class1 : INotifyPropertyChanged
    {
        public string mTest;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test { get; set; }

        public Class1()
        {
            Task.Run(async () =>
            {
                int i = 0;

                while (true)
                {
                    await Task.Delay(200);
                    Test = (i++).ToString();
                }
            });
        }
    }
}
