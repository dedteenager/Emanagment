using System;
using System.Management;
using System.Diagnostics;

public class BatteryInfo
{
    public static void Main()
    {


        int x = 1;
        while (x != 0)
        {

            Console.Write("Выберите действие: \n" +
      "1: Состояние батареи \n" +
      "2: Выключение этого ПК \n" +
      "3: Выключение целевого ПК \n" +
      "0: Выйти \n");
            x = Convert.ToInt32(Console.ReadLine());


            switch (x)
            {
                case 1:
                    infoView();
                    break;
                case 2:
                    TurnOffMy();
                    break;
                case 3:
                    TurnOffAnother();
                    break;
            }

            void TurnOffMy()
            {
                Process.Start("cmd.exe", "/C " + " shutdown /s");
            }

            void TurnOffAnother()
            {
                Process.Start("cmd.exe", "/C " + " shutdown - s - t 10 - m \\[ip-адресс компьютера в локальной сети]"); //Нужно предварително настроить другой компьютер 
            }

            void infoView()
            {
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Battery");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject battery in searcher.Get())
                {
                    string batteryStatus = battery["BatteryStatus"].ToString();
                    string batteryLevel = battery["EstimatedChargeRemaining"].ToString();

                    Console.WriteLine("Состояние батареи: " + GetBatteryStatus(batteryStatus));
                    Console.WriteLine("Уровень заряда батареи: " + batteryLevel + "%");
                }
            }
            static string GetBatteryStatus(string status)
            {
                switch (status)
                {
                    case "1": return "Отключено от сети";
                    case "2": return "Заряжается";
                    case "3": return "Полностью заряжено";
                    case "4": return "В режиме низкого заряда";
                    case "5": return "Заряжается при отключенной сети";
                    case "6": return "Аккумулятор отсутствует";
                    case "7": return "Предупреждение о низком заряде";
                    case "8": return "Ошибка зарядки";
                    case "9": return "Зарядка остановлена";
                    case "10": return "Максимальный безопасный заряд";
                    case "11": return "Неизвестное состояние";
                    case "12": return "Фактически разряженные";
                    case "13": return "блок питания во время удержания мощности";
                    case "14": return "Резерв";
                    case "15": return "Подключено, не заряжается";
                    case "16": return "В процессе оценки";
                    case "17": return "Обрыв";
                    case "18": return "Ожидаемый";
                    case "19": return "Неизвестное состояние";
                    case "20": return "Нет батареи";
                    case "21": return "Заряжается";
                    default: return "Неизвестное состояние";
                }
            }


        }

    }


    }