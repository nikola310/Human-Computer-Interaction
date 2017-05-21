using HCI_projekat2.Model;
using HCI_projekat2.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using HCI_projekat2.Tabels;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace HCI_projekat2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Dictionary<string, ResourceModel> _resursi;
        public static Dictionary<string, ResourceModel> Resursi
        {
            get
            {
                return _resursi;
            }
            set
            {
                _resursi = value;
            }
        }
        public static Dictionary<string, TypeModel> _tipovi;
        public static Dictionary<string, TypeModel> Tipovi
        {
            get
            {
                return _tipovi;
            }
            set
            {
                _tipovi = value;
            }
        }
        public static Dictionary<string, LabelModel> _etikete;
        public static Dictionary<string, LabelModel> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                _etikete = value;
            }

        }

        public string ResursiFajl;
        public string TipoviFajl;
        public string EtiketeFajl;

        public static ObservableCollection<LabelModel> obsEtikete
        {
            get;
            set;
        }
        public static ObservableCollection<TypeModel> obsTipovi
        {
            get;
            set;
        }
        public static ObservableCollection<ResourceModel> obsResursi
        {
            get;
            set;
        }

        public static ObservableCollection<ResourceModel> ikoniceResursa
        {
            get;
            set;
        }








        public static List<string> frekvencije { get; set; }

        //frekvencije
        public static string Redak = "Redak";
        public static string Cest = "Cest";
        public static string Univerzalan = "Univerzalan";

        public static List<string> mere { get; set; }

        //jedinice mere
        public static string Merica = "Merica";
        public static string Barel = "Barel";
        public static string Tona = "Tona";
        public static string Kg = "Kilogram";

        public MainWindow()
        {
            InitializeComponent();

            FileStream stream = null;
            BinaryFormatter bf = new BinaryFormatter();

            TipoviFajl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tipovi.dat");
            if (File.Exists(TipoviFajl))
            {
                try
                {
                    stream = File.Open(TipoviFajl, FileMode.Open);
                    Tipovi = (Dictionary<string, TypeModel>)bf.Deserialize(stream);
                }
                catch
                {
                    //nista
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
            }
            else
            {
                Tipovi = new Dictionary<string, TypeModel>();
            }
            stream = null;
            EtiketeFajl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etikete.dat");
            if (File.Exists(EtiketeFajl))
            {
                try
                {
                    stream = File.Open(EtiketeFajl, FileMode.Open);
                    Etikete = (Dictionary<string, LabelModel>)bf.Deserialize(stream);
                }
                catch
                {

                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
            }
            else
            {

                Etikete = new Dictionary<string, LabelModel>();
            }
            stream = null;
            ResursiFajl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resursi.dat");
            if (File.Exists(ResursiFajl))
            {
                try
                {
                    stream = File.Open(ResursiFajl, FileMode.Open);
                    Resursi = (Dictionary<string, ResourceModel>)bf.Deserialize(stream);
                }
                catch
                {

                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
            }
            else
            {
                Resursi = new Dictionary<string, ResourceModel>();
                
            }
            ikoniceResursa = new ObservableCollection<ResourceModel>();
            ucitajIkonice();

            obsEtikete = new ObservableCollection<LabelModel>(Etikete.Values);
            obsTipovi = new ObservableCollection<TypeModel>(Tipovi.Values);
            obsResursi = new ObservableCollection<ResourceModel>(Resursi.Values);

            DataContext = this;
         /*   Uri myUri = new Uri("/Images/world.jpg", UriKind.RelativeOrAbsolute);
            JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource2 = decoder2.Frames[0];

            // Draw the Image
            mapa.Source = bitmapSource2;
            mapa.Stretch = Stretch.Uniform;
            mapa.Margin = new Thickness(0);
            */
        }

        private void AddNewRes_Click(object sender, RoutedEventArgs e)
        {
            var s = new NewResourceDialog();
            s.Show();
        }

        private void NewResType_Click(object sender, RoutedEventArgs e)
        {
            var t = new NewResourceType();
            t.Show();
        }

        private void NewResLabel_Click(object sender, RoutedEventArgs e)
        {
            var l = new NewLabelDialog();
            l.Show();
        }

        private void ShowLabels_Click(object sender, RoutedEventArgs e)
        {
            var l = new LabelTable(obsEtikete);
            l.Show();
        }

        private void ShowTypes_Click(object sender, RoutedEventArgs e)
        {
            var l = new TypeTable();
            l.Show();

        }

        private void ShowRes_Click(object sender, RoutedEventArgs e)
        {
            var l = new ResourceTable();
            l.Show();
        }

        private bool TipoveS()
        {

            FileStream stream = null;
            BinaryFormatter bf = new BinaryFormatter();
            bool retVal = false;
            try
            {
                stream = File.Open("tipovi.dat", FileMode.OpenOrCreate);
                bf.Serialize(stream, _tipovi);
            }
            catch
            {
                //nista
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                    retVal = true;
                }
            }
            return retVal;
        }

        private bool EtiketeS()
        {

            FileStream stream = null;
            BinaryFormatter bf = new BinaryFormatter();
            bool retVal = false;
            try
            {
                stream = File.Open("etikete.dat", FileMode.OpenOrCreate);
                bf.Serialize(stream, _etikete);
            }
            catch
            {
                //nista
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                    retVal = true;
                }
            }
            return retVal;
        }

        private bool ResurseS()
        {

            FileStream stream = null;
            BinaryFormatter bf = new BinaryFormatter();
            bool retVal = false;
            try
            {
                stream = File.Open("resursi.dat", FileMode.OpenOrCreate);
                bf.Serialize(stream, _resursi);
            }
            catch
            {
                //nista
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                    retVal = true;
                }
            }
            return retVal;
        }

        private void ResurseS_Click(object sender, RoutedEventArgs e)
        {
            if (ResurseS())
            {
                MessageBoxResult msg;
                msg = MessageBox.Show(this, "Resursi su uspešno sačuvani.", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                MessageBoxResult msg;
                msg = MessageBox.Show(this, "Došlo je do greške prilikom čuvanja!", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TipoveS_Click(object sender, RoutedEventArgs e)
        {
            if (TipoveS())
            {
                MessageBoxResult msg;
                msg = MessageBox.Show(this, "Tipovi su uspešno sačuvani.", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                MessageBoxResult msg;
                msg = MessageBox.Show(this, "Došlo je do greške prilikom čuvanja!", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EtiketeS_Click(object sender, RoutedEventArgs e)
        {
            if (EtiketeS())
            {
                MessageBoxResult msg;
                msg = MessageBox.Show(this, "Etikete su uspešno sačuvane.", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                MessageBoxResult msg;
                msg = MessageBox.Show(this, "Došlo je do greške prilikom čuvanja!", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Sacuvaj_Sve_Click(object sender, RoutedEventArgs e)
        {
            if (EtiketeS() && ResurseS() && TipoveS())
            {
                MessageBoxResult msg;
                msg = MessageBox.Show(this, "Podaci su uspešno sačuvani.", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                MessageBoxResult msg;
                msg = MessageBox.Show(this, "Došlo je do greške prilikom čuvanja!", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult msb = MessageBox.Show("Želite li da sačuvate unete izmene?", "Čuvanje pre zatvaranja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (msb == MessageBoxResult.Yes)
            {
                EtiketeS();
                TipoveS();
                ResurseS();
            }
            base.OnClosing(e);
        }

        public void ucitajIkonice()
        {
            foreach(ResourceModel model in Resursi.Values)
            {
                /*if(model.Point.X != 0 && model.Point.Y != 0)
                {

                }else
                {*/
                    ikoniceResursa.Add(model);
                
            }
        }

        public  void iscrtajOpet()
        {
            listaIkonica.UpdateLayout();
        }
    }
}

