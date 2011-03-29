using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using AxShockwaveFlashObjects;

namespace Surface {
	/// <summary>
	/// Interaction logic for SurfaceWindow1.xaml
	/// </summary>
	public partial class MyWindow : SurfaceWindow {

		// Double backslash counts as one backslash!
		private const string applicationPath = "\\Rotterdam.swf";

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MyWindow() {
			InitializeComponent();

			// Add handlers for Application activation events
			AddActivationHandlers();
		}


		/// <summary>
		/// Occurs when the window is about to close. 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);

			// Remove handlers for Application activation events
			RemoveActivationHandlers();
		}

		/// <summary>
		/// Adds handlers for Application activation events.
		/// </summary>
		private void AddActivationHandlers() {
			// Subscribe to surface application activation events
			ApplicationLauncher.ApplicationActivated += OnApplicationActivated;
			ApplicationLauncher.ApplicationPreviewed += OnApplicationPreviewed;
			ApplicationLauncher.ApplicationDeactivated += OnApplicationDeactivated;
		}

		/// <summary>
		/// Removes handlers for Application activation events.
		/// </summary>
		private void RemoveActivationHandlers() {
			// Unsubscribe from surface application activation events
			ApplicationLauncher.ApplicationActivated -= OnApplicationActivated;
			ApplicationLauncher.ApplicationPreviewed -= OnApplicationPreviewed;
			ApplicationLauncher.ApplicationDeactivated -= OnApplicationDeactivated;
		}

		/// <summary>
		/// This is called when application has been activated.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnApplicationActivated(object sender, EventArgs e) {
			//TODO: enable audio, animations here
		}

		/// <summary>
		/// This is called when application is in preview mode.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnApplicationPreviewed(object sender, EventArgs e) {
			//TODO: Disable audio here if it is enabled

			//TODO: optionally enable animations here
		}

		/// <summary>
		///  This is called when application has been deactivated.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnApplicationDeactivated(object sender, EventArgs e) {
			//TODO: disable audio, animations here
		}

		private void WindowLoaded(object sender, RoutedEventArgs e) {
			AxShockwaveFlash axFlash = wfh.Child as AxShockwaveFlash;
			axFlash.Movie = System.Windows.Forms.Application.StartupPath + applicationPath;
			axFlash.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(axFlash_FlashCall);
		}

		private void axFlash_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e) {

		}

	}
}