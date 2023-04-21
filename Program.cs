/* C#, lesson_39  08.04.2023																																
																																
Task № 2:																																
Створіть клас «Магазин», який має зберігати таку інформацію:																																
? назва магазину;																																
? адреса магазину;																																
? тип магазину:																																
o продовольчий,																																
o господарський,																																
o одяг,																																
o взуття.																																
Реалізуйте у класі методи та властивості, необхідні для функціонування класу.																																
Клас має реалізовувати інтерфейс IDisposable. Напишіть код для тестування функціональності класу.																																
Напишіть код для виклику методу Dispose.																																
																																
Task № 3:																																
Додайте до другого завдання реалізацію фіналізатора. Напишіть код для тестування нових можливостей.*/
//--------------------------------------------------------------------------------------------------------																																
using System;
using System.Globalization;

namespace Lesson_39
{

    enum Goods
    {
        FOOD = 1,
        HOUSEGOODS,
        CLOTHES,
        FOOTWEAR
    }
    //--------------------------------------------------------------------------------------------------------																																
    class Shop : IDisposable                    // оголошення класу																																
    {
        private string name;
        private string address;
        private string type;


        public string NAME
        {
            set { this.name = value; }
            get { return this.name; }
        }

        public string ADDRESS
        {
            set { this.address = value; }
            get { return this.address; }
        }

        public string TYPE
        {
            set { this.type = value; }
            get { return this.type; }
        }

        public Shop() { }

        public Shop(string name, string address, string type)
        {
            NAME = name;
            ADDRESS = address;
            TYPE = type;
        }

        public override string ToString()
        {
            return ($"\nInfo about shop: \n\nName: { NAME }" +
                    $"\nAddress: { ADDRESS } \nType of goods: { TYPE }" +
                    "\n================================================================================ ");
        }

        public void Dispose()
        {
            Console.WriteLine($"Shop \"{ this.NAME}\" was deleted using disposer.");
            GC.SuppressFinalize(this);
        }

        ~Shop()
        {
            Console.WriteLine($"Shop \"{ this.NAME}\" was deleted using finalizer.");
        }
    }

    /*********************************************************************************************************************/
    internal class Program_2
    {

        //--------------------------------------------------------------------------------------------------------																																
        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_39 \"Task 2\"\n");

            int index;

            long memory = GC.GetTotalMemory(false);

            Shop shop_1 = new Shop("ATB", "Dnipro", Convert.ToString(Goods.FOOD));
            Shop shop_2 = new Shop("Brain", "Lviv", Convert.ToString(Goods.HOUSEGOODS));
            Shop shop_3 = new Shop("Guliver", "Kyiv", Convert.ToString(Goods.CLOTHES));
            Shop shop_4 = new Shop("Progres", "Kharkiv", Convert.ToString(Goods.FOOTWEAR));

            Console.WriteLine($"\n\nMemory of all variables after deleting shop # 1: {GC.GetTotalMemory(false) - memory} bytes");

            Console.WriteLine(shop_1.ToString());
            Console.WriteLine(shop_2.ToString());
            Console.WriteLine(shop_3.ToString());
            Console.WriteLine(shop_4.ToString());

            Console.WriteLine($"\n\nMemory of all variables: {GC.GetTotalMemory(false) - memory} bytes");

            Console.WriteLine($"Count of generations: {GC.MaxGeneration + 1}");

            Console.WriteLine($"Shop # 1, generation {GC.GetGeneration(shop_1)}");
            Console.WriteLine($"Shop # 2, generation {GC.GetGeneration(shop_2)}");
            Console.WriteLine($"Shop # 3, generation {GC.GetGeneration(shop_3)}");
            Console.WriteLine($"Shop # 4, generation {GC.GetGeneration(shop_4)}");

            GC.Collect();
            Console.WriteLine("Info about shops after cleaning #1: ");
            Console.WriteLine($"Shop # 1, generation {GC.GetGeneration(shop_1)}");
            Console.WriteLine($"Shop # 2, generation {GC.GetGeneration(shop_2)}");
            Console.WriteLine($"Shop # 3, generation {GC.GetGeneration(shop_3)}");
            Console.WriteLine($"Shop # 4, generation {GC.GetGeneration(shop_4)}");

            GC.Collect();
            Console.WriteLine("Info about shops after cleaning #2: ");
            Console.WriteLine($"Shop # 1, generation {GC.GetGeneration(shop_1)}");
            Console.WriteLine($"Shop # 2, generation {GC.GetGeneration(shop_2)}");
            Console.WriteLine($"Shop # 3, generation {GC.GetGeneration(shop_3)}");
            Console.WriteLine($"Shop # 4, generation {GC.GetGeneration(shop_4)}");


            //----------------------------------------------------------------------------------------------------------------------------------------																																
            Console.Write("\n\nSelect the type of deletion for shop # 1 (1 - disposer, other - finalizer): ");
            index = Convert.ToInt32(Console.ReadLine());

            if (index == 1)
            {
                shop_1.Dispose();
            }
            else
            {
                shop_1 = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine($"\n\nMemory of all variables after deleting shop # 1: {GC.GetTotalMemory(false) - memory} bytes");

            //----------------------------------------------------------------------------------------------------------------------------------------																																
            Console.Write("\nSelect the type of deletion for shop # 2 (1 - disposer, other - finalizer): ");
            index = Convert.ToInt32(Console.ReadLine());

            if (index == 1)
            {
                shop_2.Dispose();
            }
            else
            {
                shop_2 = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine($"\n\nMemory of all variables after deleting shop # 2: {GC.GetTotalMemory(false) - memory} bytes");

            //----------------------------------------------------------------------------------------------------------------------------------------																																
            Console.Write("\nSelect the type of deletion for shop # 3 (1 - disposer, other - finalizer): ");
            index = Convert.ToInt32(Console.ReadLine());

            if (index == 1)
            {
                shop_3.Dispose();
            }
            else
            {
                shop_3 = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine($"\n\nMemory of all variables after deleting shop # 3: {GC.GetTotalMemory(false) - memory} bytes");

            //----------------------------------------------------------------------------------------------------------------------------------------																																
            Console.Write("\nSelect the type of deletion for shop # 4 (1 - disposer, other - finalizer): ");
            index = Convert.ToInt32(Console.ReadLine());

            if (index == 1)
            {
                shop_4.Dispose();
            }
            else
            {
                shop_4 = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine($"\n\nMemory of all variables after deleting shop # 4: {GC.GetTotalMemory(false) - memory} bytes");

            //--------------------------------------------------------------------------------------------------------																																

            Console.WriteLine("\n\nThe shops went bankrupt ...\n\n");
        }
    }
}
