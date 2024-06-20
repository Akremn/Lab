using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace Lab3Zv1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Horse[] _horses;
        private Horse[] _horseOnScreen;
        private CancellationTokenSource _cancellationTokenSource;
        private int BankAccount { get; set; }
        private int Reserve = 20;
        private string HorseBetName { get; set; }
        private int horseIndex = 1;
        public MainWindow()
        {
            InitializeComponent();

            Random random = new Random();

            _horses = new Horse[5]
            {
                new Horse("Вітер", Brushes.DeepSkyBlue, random),
                new Horse("Блискавка", Brushes.MediumPurple, random),
                new Horse("Оріон", Brushes.Navy, random),
                new Horse("Сокіл", Brushes.LightPink, random),
                new Horse("Грім", Brushes.Firebrick, random)
            };

            _horseOnScreen = (Horse[])_horses.Clone();

            BankAccount = 250;
        }

        public void StopProcess()
        {
            _cancellationTokenSource?.Cancel();
        }

        public void SetHorses(Horse[] horses)
        {
            Dispatcher.Invoke(() =>
            {
                UpdateHorseInformation(horses[0], firstColor, firstName, firstCoefficient, firstTime, firstPosition);
                UpdateHorseInformation(horses[1], secondColor, secondName, secondCoefficient, secondTime, secondPosition);
                UpdateHorseInformation(horses[2], thirdColor, thirdName, thirdCoefficient, thirdTime, thirdPosition);
                UpdateHorseInformation(horses[3], fourthColor, fourthName, fourthCoefficient, fourthTime, fourthPosition);
                UpdateHorseInformation(horses[4], fifthColor, fifthName, fifthCoefficient, fifthTime, fifthPosition);
            });
        }

        public void UpdateHorseInformation(Horse horse, Rectangle color, Label name, Label acceration, Label time, Label position)
        {
            color.Fill = horse.Color;
            name.Content = horse.Name;
            acceration.Content = horse.Accelaration;
            time.Content = horse.Timer.Elapsed;
            position.Content = horse.Position;
        }

        public async Task LaunchHorses(Horse[] horses, Random random, CancellationToken token)
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < horses.Length; i++)
            {
                tasks.Add(horses[i].RunAsync(random));
            }

            await Task.WhenAll(tasks);
        }

        private List<Task> RenderHorseAnimation(CancellationToken token)
        {
            List<List<ImageSource>> horsesAnimation = new List<List<ImageSource>>();

            Color[] colors = new Color[5] { Colors.DeepSkyBlue, Colors.MediumPurple, Colors.Navy, Colors.LightPink, Colors.Firebrick };

            foreach (var color in colors)
            {
                horsesAnimation.Add(GetHorseAnimation(color));
            }

            List<Task> horsesTask = new List<Task>();
            horsesTask.Add(PlayAnimation(horsesAnimation[0], horse_1, token));
            horsesTask.Add(PlayAnimation(horsesAnimation[1], horse_2, token));
            horsesTask.Add(PlayAnimation(horsesAnimation[2], horse_3, token));
            horsesTask.Add(PlayAnimation(horsesAnimation[3], horse_4, token));
            horsesTask.Add(PlayAnimation(horsesAnimation[4], horse_5, token));

            return horsesTask;
        }
        private async void RunProgram(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancellationTokenSource.Token;
            Random random = new Random();

            List<Task> horsesAnimation = RenderHorseAnimation(token);
            Task updateRatingPositionHorses = UpdateRatingPositionHorses(token);
            Task launchHorses = LaunchHorses(_horses, random, token);
            Task changePositionHorses = ChangePositionHorses(token);

            await Task.WhenAll(horsesAnimation);
            await Task.WhenAll(updateRatingPositionHorses, launchHorses, changePositionHorses);

            MessageBox.Show("Гонка закінчена");
        }

        private async Task PlayAnimation(List<ImageSource> animationFrames, Image targetImage, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                foreach (var frame in animationFrames)
                {
                    if (token.IsCancellationRequested)
                        break;

                    targetImage.Dispatcher.Invoke(() => targetImage.Source = frame);
                    await Task.Delay(TimeSpan.FromSeconds(0.1));
                }
            }
        }

        private void PositionChanges(Image horse, int i)
        {
            double horseChangePositionValue = _horseOnScreen[i].Position % 800;
            horse.Margin = new Thickness(horseChangePositionValue, 0, 0, 0);
        }

        private async Task ChangePositionHorses(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Dispatcher.Invoke(() =>
                {
                    PositionChanges(horse_1, 0);
                    PositionChanges(horse_2, 1);
                    PositionChanges(horse_3, 2);
                    PositionChanges(horse_4, 3);
                    PositionChanges(horse_5, 4);
                });

                await Task.Delay(10); // Используем await Task.Delay для асинхронности
            }
        }

        public List<ImageSource> GetHorseAnimation(Color color)
        {
            const int count = 12;
            var bitmap_image_list = ReadImageList(@"Images\Horses", "WithOutBorder_", ".png", count);
            var mask_image_list = ReadImageList(@"Images\HorsesMask", "mask_", ".png", count);

            return bitmap_image_list.Select((item, index) => GetImageWithColor(item, mask_image_list[index], color)).ToList();
        }

        private List<BitmapImage> ReadImageList(string path, string name, string format, int count)
        {
            path = $@"C:\Users\GAIFo\source\repos\Lab3Zv1\Lab3Zv1\{path}\{name}";
            List<BitmapImage> list = new List<BitmapImage>();
            for (int i = 0; i < count; i++)
            {
                var uri = path + string.Format("{0:0000}", i) + format;
                var img = new BitmapImage(new Uri(uri));
                list.Add(img);
            }

            return list;
        }

        private ImageSource GetImageWithColor(BitmapImage image, BitmapImage mask, Color color)
        {
            WriteableBitmap image_bmp = new WriteableBitmap(image);
            WriteableBitmap mask_bmp = new WriteableBitmap(mask);
            WriteableBitmap output_bmp = BitmapFactory.New(image.PixelWidth, image.PixelHeight);
            output_bmp.ForEach((x, y, z) =>
            {
                var originalPixel = image_bmp.GetPixel(x, y);
                var maskPixel = mask_bmp.GetPixel(x, y);
                return MultiplyColors(originalPixel, color, maskPixel.A);
            });

            return output_bmp;
        }

        private Color MultiplyColors(Color color_1, Color color_2, byte alpha)
        {
            var amount = alpha / 255.0;
            byte r = (byte)(color_2.R * amount + color_1.R * (1 - amount));
            byte g = (byte)(color_2.G * amount + color_1.G * (1 - amount));
            byte b = (byte)(color_2.B * amount + color_1.B * (1 - amount));
            return Color.FromArgb(color_1.A, r, g, b);
        }

        public async Task UpdateRatingPositionHorses(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (!_horses.Any(h => h.Timer.IsRunning)) // Проверяем, что все таймеры остановлены
                {
                    _horses = Horse.ChangePositionRaiting(_horses);

                    if (!string.IsNullOrEmpty(HorseBetName) && HorseBetName.Contains(_horses[0].Name))
                    {
                        BankAccount += Reserve * 2;
                    }

                    Dispatcher.Invoke(() =>
                    {
                        BalanceContent.Content = $"Баланс: {BankAccount}$";
                    });

                    StopProcess();
                }

                Dispatcher.Invoke(() =>
                {
                    SetHorses(_horses);
                });

                _horses = Horse.ChangePlace(_horses);

                await Task.Delay(100); // Добавляем задержку для асинхронности
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            horseIndex %= 5;
            HorsesNameContent.Content = $"{horseIndex + 1}. " + _horses[horseIndex].Name;
            horseIndex++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (horseIndex == 0)
            {
                horseIndex = _horses.Length - 1;
            }
            else
            {
                horseIndex--;
            }

            HorsesNameContent.Content = $"{horseIndex + 1}. " + _horses[horseIndex].Name;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Reserve += 5;
            MoneyThatPayed.Content = Reserve.ToString() + "$";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Reserve > 0)
            {
                Reserve -= 5;
            }
            MoneyThatPayed.Content = Reserve.ToString() + "$";
        }

        private void Bet(object sender, RoutedEventArgs e)
        {
            if (BankAccount - Reserve >= 0)
            {
                BankAccount -= Reserve;
                BalanceContent.Content = $"Баланс: {BankAccount}$";
                MessageBox.Show($"Ви поставили на {HorsesNameContent.Content} {Reserve}$");
                HorseBetName = HorsesNameContent.Content.ToString();
            }
            else
            {
                MessageBox.Show($"Не достатньо грошей. Потрібно ще {Reserve - BankAccount}");
            }
        }
    }
}
