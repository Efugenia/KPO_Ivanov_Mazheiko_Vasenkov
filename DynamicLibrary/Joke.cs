using System;
using System.Windows;


namespace DynamicLibrary
{
    public static class Jokes
    {
        public static string[] jokes = {"����� ����� �� ������, � ������� ���.",
        "������� ��������� � ��������� � ����������:\n � ��� �� ��� ������� ��������?\n���� ������ ���� �������. ���� ��������� ��� ������� �������",
        "������ � �� ������� ����� �������� � ��������? ������ ��� ����� ��� �� �������.", "������ ������ � ����� ��������? ���.", "�� ��������� �������� ������ ������� ��������� ����. �� ��� �� ��������", 
        "\"����� ��� ������, ��������� ��� �������\"\n\n���������� ��������� � ������� ������ ������, ��� �� �������."};

        public static void GetRandomJoke()
        {   
            Random random = new Random();
            int index = random.Next(0, jokes.Length);
            string joke = jokes[index];

            MessageBox.Show(joke);
        }
    }
}
