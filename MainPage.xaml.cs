using System.ComponentModel;
using System.Net.Http.Headers;

namespace MAUI_MobileApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        CarouselView carouselView = new CarouselView
        {
            VerticalOptions = LayoutOptions.Center,
        };
        carouselView.ItemsSource = new List<Product>
        {
            new Product { Name="Name1", Description="Dis1", Image="dotnet_bot.svg"},
            new Product { Name="Name2", Description="Dis2", Image="dotnet_bot.svg"},
            new Product { Name="Name3", Description="Dis3", Image="dotnet_bot.svg"},
        };
        carouselView.ItemTemplate = new DataTemplate(() =>
        {
            Label header = new Label
            {
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 18
            };
            header.SetBinding(Label.TextProperty, "Name");

            Image image = new Image { WidthRequest = 150, HeightRequest = 150 };
            image.SetBinding(Image.SourceProperty, "Image");

            Label description = new Label { HorizontalTextAlignment = TextAlignment.Center };
            description.SetBinding(Label.TextProperty, "Description");

            StackLayout stacklayout = new StackLayout() { header, image, description };
            Frame frame = new Frame();
            frame.Content = stacklayout;
            return frame;
        });
        Content = carouselView;
    }
}