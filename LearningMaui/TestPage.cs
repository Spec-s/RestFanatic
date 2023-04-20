namespace LearningMaui
{
	public class TestPage : ContentPage
	{
        int count = 0;
        Label counterLabel;

        public TestPage ()
		{
			var scrollView = new ScrollView ();
			var stackLayout = new StackLayout ();

			scrollView.Content = stackLayout;

			counterLabel = new Label
			{
				Text = "Count: 0",
				FontSize = 22,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
			};
			stackLayout.Children.Add (counterLabel);

			var btnCounter = new Button
			{
				Text = "Click to count",
				HorizontalOptions = LayoutOptions.Center,
			};
			stackLayout.Children.Add (btnCounter);

			this.Content = scrollView;
		}
	}
}