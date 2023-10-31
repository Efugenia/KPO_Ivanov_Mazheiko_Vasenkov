using System;
using System.Windows;


namespace DynamicLibrary
{
    public static class Jokes
    {
        public static string[] jokes = {"Вышел мужик на балкон, а балкона нет.",
        "Заходит профессор в аудиторию и спрашивает:\n — Кто из вас Альберт Эйнштейн?\nРуку поднял один человек. Этим человеком был Альберт Эйштейн",
        "Почему я не уступаю место бабушкам в автобусе? Потому что бабки это не главное.", "Худшая оценка в школе вампиров? Кол.", "На директора АвтоВАЗа хотели завести уголовное дело. Но оно не завелось", 
        "\"Мусор для одного, сокровище для другого\"\n\nПрекрасное выражение и ужасный способ узнать, что ты приёмный."};

        public static void GetRandomJoke()
        {   
            Random random = new Random();
            int index = random.Next(0, jokes.Length);
            string joke = jokes[index];

            MessageBox.Show(joke);
        }
    }
}
