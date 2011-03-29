using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Form {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MyWindow : Window {

		// Double backslash counts as one backslash!
		private const string applicationPath = "\\Rotterdam.swf";

		public MyWindow() {
			InitializeComponent();
		}

		private void WindowLoaded(object sender, RoutedEventArgs e) {
			AxShockwaveFlashObjects.AxShockwaveFlash axFlash = wfh.Child as AxShockwaveFlashObjects.AxShockwaveFlash;
			axFlash.Movie = System.Windows.Forms.Application.StartupPath + applicationPath;
			axFlash.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(axFlash_FlashCall);
		}

		private void axFlash_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e) {

		}

	}
}
