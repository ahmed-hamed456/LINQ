using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using static LINQ_Test.ListGenerator;
namespace LINQ_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LinQSyntax 
            // LINQ Have Two Syntax :

            //List<int> Numbers = new List<int>() { 80, 15, 94, 101 };


            //1 ==> fluentSynatax
            // a- Throught StaticMethods 
            //var numbers1 = Enumerable.Where(Numbers, (N) => N % 2 > 0);


            // b- Throught ExtensionsMethods 
            //var numbers2 = Numbers.Where((N) => N % 2 == 0);


            // 2==>  QuerySyntax  
            //var number3  = from N in Numbers
            //               where N % 2 == 0 
            //               select N;

            //foreach (var number in numbers1) 
            //    Console.WriteLine("StaticMethods == > " + number);


            //foreach (var number in numbers2)
            //    Console.WriteLine("ExtensionsMethods == > " + number);

            //foreach (var number in number3)
            //    Console.WriteLine("QuerySyntax == > " + number);
            #endregion

            #region LINQ Execution Ways 

            // 1.Differed Execution (Latest version of Data)

            //List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var oddNumbers = Numbers.Where(N => N % 2 == 1);

            //Numbers.AddRange(new int[] { 11, 12, 13, 14, 15 });

            //foreach (int n in oddNumbers)
            //    Console.WriteLine(n);

            // 2.Immediate Execution (Elements operators , casting operators , Aggregate operators)

            //List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var oddNumbers = Numbers.Where(N => N % 2 == 1).ToList();

            //Numbers.AddRange(new int[] { 11, 12, 13, 14, 15 });

            //foreach (int n in oddNumbers)
            //    Console.WriteLine(n);
            #endregion

            //Categories
            //Differed
            #region 1- Filteration (Restrication) operator - Where

            // ==> First Overload 
            //var Result = ProductsList.Where((P) => P.UnitsInStock == 0);

            //Result = from P in ProductsList
            //         where P.UnitsInStock == 0
            //         select P;

            //var Result = ProductsList.Where(P => P.UnitsInStock > 0 && P.Category == "Meat/Poultry");

            //Result = from P in ProductsList
            //         where P.UnitsInStock > 0 && P.Category == "Meat/Poultry"
            //         select P;


            // ==> Second Overload
            //==> Indexed Where
            //Valid only at fluent syntax, can`t be writen Using Query Expression
            //Get from the first 10 products ,The products that are out of stock

            //var Result = ProductsList.Where((P, I) => I < 10 && P.UnitsInStock == 0);

            //foreach (var item in Result)
            //    Console.WriteLine(item);
            #endregion

            #region 2- Transformation (Projection) Operators - Select / SelectMany
            //var Result = ProductsList.Select((P) => P.ProductName);

            //Result = from P in ProductsList
            //         select P.ProductName;

            //var Result = ProductsList.Select(P => new { Id = P.ProductID,Name = P.ProductName });
            //==> Result here is list of Anonymous object

            //Result = from P in ProductsList
            //         select new
            //         {
            //            Id = P.ProductID,
            //            Name = P.ProductName
            //         };


            //var disCountedList = ProductsList.Where(P => P.UnitsInStock > 0)
            //                                 .Select(P => new
            //                                 {
            //                                     Id = P.ProductID,
            //                                     Name = P.ProductName,
            //                                     NEWPrice = P.UnitPrice - (P.UnitPrice * 0.1M)
            //                                 });

            //disCountedList = from P in ProductsList
            //                 where P.UnitsInStock > 0
            //                 select new
            //                 {
            //                     Id = P.ProductID,
            //                     Name = P.ProductName,
            //                     NEWPrice = P.UnitPrice -  (P.UnitPrice * 0.1M)
            //                 };

            //Indexed Select
            //Valid only at fluent syntax, can`t be writen Using Query Expression
            //var Result = ProductsList.Select((P, I) => new { Index = I, Name = P.ProductName });


            //var Result = Customer.SelectMany((C) => C.Orders);

            //foreach (var item in Result)
            //    Console.WriteLine(item);
            #endregion

            #region 3- Ordering Operators - (OrderBy/OrderByDescendin/Reverse)
            //var Result = ProductsList.OrderBy(P => P.UnitsInStock);

            //Result = from P in ProductsList
            //         orderby P.UnitsInStock
            //         select P;


            //var Result = ProductsList.OrderBy(P => P.UnitsInStock)
            //                         .ThenBy(P => P.UnitPrice);

            //Result = from P in ProductsList
            //         orderby P.UnitsInStock , P.UnitPrice
            //         select P;

            //var Result2 = ProductsList.OrderByDescending(P => P.UnitsInStock);

            //Result2 = from P in ProductsList
            //          orderby P.UnitsInStock descending
            //          select P;

            //Where,Reverse
            //var Result = ProductsList.Where(P => P.UnitsInStock == 0).Reverse();

            //foreach (var item in Result)
            //    Console.WriteLine(item);

            #endregion

            #region 4- Generation Operator
            //The only way for calling these Operators => as static method throught "Enumerable" Class

            //var Result = Enumerable.Range(0, 100); //0..99

            //var Result = Enumerable.Repeat(new Product(), 100); 

            //var Result = Enumerable.Empty<Product>(); //Empty Sequence

            //foreach (var item in Result)
            //    Console.Write($"{item},");
            #endregion

            #region 5- Set Operators - Union Family
            //var seq1 = Enumerable.Range(0, 100); //0..99

            //var seq2 = Enumerable.Range(50, 100); //50..149

            //var Result = seq1.Union(seq2); //0...99..100...149 Without any duplicates

            //Result = seq1.Concat(seq2); //0...99..50..149 With duplicates

            //Result = Result.Distinct(); //Remove duplicates

            //Result = seq1.Intersect(seq2); //50...99

            //Result = seq1.Except(seq2); //0..49

            ////////////////////////////////////////////////////////////////

            //var seq1 = new List<Product>()
            //{
            //        new Product() {ProductID = 1, ProductName = "Chai", Category = "Beverages",
            //                UnitPrice = 18.00M, UnitsInStock = 100},
            //        new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages",
            //                UnitPrice = 19.0000M, UnitsInStock = 17 },
            //        new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments",
            //                UnitPrice = 10.0000M, UnitsInStock = 13 }
            //};

            //var seq2 = new List<Product>()
            //{
            //          new Product() {ProductID = 1, ProductName = "Chai", Category = "Beverages",
            //                UnitPrice = 18.00M, UnitsInStock = 100},
            //          new Product{ ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments",
            //                UnitPrice = 21.3500M, UnitsInStock = 0 },
            //          new Product{ ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments",
            //                UnitPrice = 25.0000M, UnitsInStock = 120 }
            //};

            //var Result = seq1.Union(seq2);

            // Result = seq1.Union(seq2,new MyEqualityComparer());

            //var Result2 = seq1.UnionBy(seq2, P => P.ProductID);


            //Result = seq1.Intersect(seq2); 

            //Result = seq1.Intersect(seq2, new MyEqualityComparer());

            //var Result2 = seq1.IntersectBy(seq2.Select(P=>P.ProductID), P => P.ProductID);

            //Result = seq1.Distinct(new MyEqualityComparer());

            //Result = seq1.Except(seq2, new MyEqualityComparer());


            //foreach (var item in Result)
            //    Console.WriteLine($"{item} ");
            #endregion

            #region 6- Quantifier Operators - Returns Boolean

            //var seq1 = Enumerable.Range(0, 100); //0..99
            //var seq2 = Enumerable.Range(50, 100); //50..149

            //Console.WriteLine
            //    (
            //    //ProductsList.Any() //Return True, if sequence contains at least ONE Element
            //    //ProductsList.Any(P => P.UnitsInStock == 0) //Return True,if sequence contains at least ONE Element Mached the Condition
            //    //ProductsList.All(P => P.UnitPrice > 0 )
            //    //seq1.SequenceEqual(seq2)
            //    );

            #endregion

            #region 7- Zipping Operator
            //List<string> Words = new List<string>() { "Ten", "Twenty", "Thirty", "Forty" };

            //int [] Numbers = { 10, 20, 30, 40, 50, 60 };

            //var Result = Words.Zip(Numbers, (Word, Number) => $"{Number} - {Word}");

            //foreach ( var item in Result )
            //    Console.WriteLine(item);
            #endregion

            #region 8- Grouping Operators

            //var Categories = from P in ProductsList
            //                 group P by P.Category;

            //Categories = ProductsList.GroupBy(p => p.Category);

            //foreach(var Category in Categories)
            //{
            //    Console.WriteLine(Category.Key); //Key => it is a Category that I Group based on it

            //    foreach(var Product in Category)
            //        Console.WriteLine($"......{Product}");
            //}


            //var Categories = from P in ProductsList
            //                 where P.UnitsInStock > 0
            //                 group P by P.Category
            //                 into Category
            //                 where Category.Count() > 10
            //                 select new { CategoryName = Category.Key, CountOfProduct = Category.Count() }; ;

            //var Categories1 = ProductsList.Where(P => P.UnitsInStock > 0)
            //                              .GroupBy(P => P.Category)
            //                              .Where(Category => Category.Count() > 10)
            //                              .Select(Category => new
            //                              {
            //                                  CategoryName = Category.Key,
            //                                  CountOfProduct = Category.Count()
            //                              });

            //foreach (var Category in Categories)
            //{
            //    Console.WriteLine(Category); 
            //}

            #endregion

            #region 9- Partioning Operators - Take,TakeLast,Skip,SkipLast,TakeWhile,SkipWhile

            //var Result = ProductsList.Where(P => P.UnitsInStock == 0).Take(5);

            // Result = ProductsList.Where(P => P.UnitsInStock == 0).TakeLast(5);

            // Result = ProductsList.Where(P => P.UnitsInStock == 0).Skip(3);

            // Result = ProductsList.Where(P => P.UnitsInStock == 0).SkipLast(3);


            //int[] Numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //Get the elements starting from the beginning of the array until the Number is hit that
            //less than its position in the array
            //var Result = Numbers.TakeWhile((Number, Index) => Number > Index);

            //Get the elements of the array starting from the first element divisible by 3
            //var Result = Numbers.SkipWhile(Number => Number % 3 != 0);

            //foreach (int item in Result)
            //    Console.WriteLine(item);

            #endregion

            //Immediate
            #region 1- Element Operators - Immediate Execution
            //Valid Only With Fluent Syntax

            // ==> First Overrload
            //var Result = ProductsList.First();

            //Result = ProductsList.Last();

            // ==> Second Overrload
            //var Result = ProductsList.First(P => P.UnitsInStock == 0);
            // Result = ProductsList.Last(P => P.UnitsInStock == 0);

            ////////////////////////////////////////////////////

            // ==> First Overrload
            //var Result = ProductsList.FirstOrDefault();

            //Result = ProductsList.LastOrDefault();

            // ==> Second Overrload
            //var Result = ProductsList.FirstOrDefault(new Product { ProductName = "Tea"});

            //Result = ProductsList.LastOrDefault(new Product { ProductName = "Tea" });

            // ==> Third Overrload
            //var Result = ProductsList.FirstOrDefault(P => P.UnitPrice > 1000);

            //Result = ProductsList.LastOrDefault(P => P.UnitPrice > 1000);


            // ==> Forth Overrload
            //var Result = ProductsList.FirstOrDefault(P => P.UnitPrice > 1000, 
            //                        new Product { ProductName = "Tea", UnitPrice = 1000 });

            //var Result = ProductsList.LastOrDefault(P => P.UnitPrice > 1000,
            //                        new Product { ProductName = "Tea", UnitPrice = 1000 });


            /////////////////////////////////////////////////////

            //var Result = ProductsList.ElementAt(22);

            //Result = ProductsList.ElementAtOrDefault(1000);



            //var DiscountedProducts = new List<Product>() { ProductsList[0] };

            //var Result = DiscountedProducts.Single();

            //Result = DiscountedProducts.SingleOrDefault();
            ///If sequence is empty,Will Return Default
            ///If sequence contains Just only one Element,Will return single element
            ///If sequence contains more than one Element,Throw Exception


            //Result = DiscountedProducts.SingleOrDefault(new Product() { ProductName = "Tea" });
            ///If sequence is empty,Will Return specified default value 
            ///If sequence contains Just only one Element,Will return single element
            ///If sequence contains more than one Element,Throw Exception

            //Result = ProductsList.Single(P => P.ProductID == 22);
            ///If the sequence contain just only one element maching the condition,Will return Single Element
            ///Throw Exception,if zero or more one element is maching the condition

            //Result = ProductsList.SingleOrDefault(P => P.ProductID == 22);
            ///If sequence No Element Maching Condition,Will Return default value 
            ///If the sequence contain just only one element maching the condition,Will return single element
            ///If sequence contains more than one Element maching the condition,Will Throw Exception

            //Result = ProductsList.SingleOrDefault(P => P.ProductID == 22, new Product() { ProductName = "Tea" });
            ///If sequence No Element Maching Condition,Will Return specified default value 
            ///If the sequence contain just only one element maching the condition,Will return single element
            ///If sequence contains more than one Element maching the condition,Will Throw Exception


            //Hybrid Syntax (QureySyntax).FluentSyntax
            //var Result = (from P in ProductsList
            //             where P.UnitsInStock == 0
            //             select P).FirstOrDefault();

            //Console.WriteLine(Result?.ProductName ?? "NA");

            #endregion

            #region 2- Aggregate Operators - Immediate Execution

            //var Result = ProductsList.Count();
            //Result = ProductsList.Count;

            //Result = ProductsList.Where(P => P.UnitsInStock == 0).Count();

            //Result = ProductsList.Count(P => P.UnitsInStock == 0);


            //var Result = ProductsList.OrderByDescending(P=>P.UnitPrice).FirstOrDefault();
            ///==>
            //Result = ProductsList.MaxBy(P=>P.UnitPrice);

            //Result = ProductsList.OrderBy(P => P.UnitPrice).FirstOrDefault();
            ///==>
            //Result = ProductsList.MinBy(P => P.UnitPrice);

            //var Result = ProductsList.Max(P => P.ProductName);

            // Result = ProductsList.Min(P => P.ProductName);


            //var Result = ProductsList.Max(new MaxUnitInStockComparer());


            /////////////////////////////////////

            //int[] Numbers = { 5, 8, 7, 41, 9, 4, 2, 6, 71, 1, 25, 65, 78, 12 };


            //Array.Sort(Numbers,new MyComparer());

            //foreach (int num in Numbers)
            //    Console.WriteLine(num);

            ////////////////////////////////////////

            //var Result = ProductsList.Sum(P => P.UnitPrice);

            //Result = ProductsList.Average(P => P.UnitPrice);

            //Console.WriteLine(Result);

            ///////////////////////////////////////////

            //string Message = "Hello";

            //string[] Names = { "Ahmed", "Mohamed", "Hamed" };

            //var FullName = Names.Aggregate((str1, str2) => $"{str1} {str2}");

            ////==>Second overrload
            //FullName = Names.Aggregate(Message, (str1, str2) => $"{str1} {str2}");


            //Console.WriteLine(FullName);
            #endregion

            #region 3- Casting Operator - Immediate Execution

            //List<Product> List = ProductsList.Where(P => P.UnitsInStock == 0).ToList();

            //Product[] array = ProductsList.Where(P => P.UnitsInStock == 0).ToArray();

            //Dictionary<long, Product> dictionary = ProductsList.Where(P => P.UnitsInStock == 0)
            //                                                  .ToDictionary(P => P.ProductID);

            //Dictionary<long, string> dictionary2 = ProductsList.Where(P => P.UnitsInStock == 0)
            //                                                  .ToDictionary(P => P.ProductID, P => P.ProductName);

            //HashSet<Product> set = ProductsList.Where(P => P.UnitsInStock == 0).ToHashSet();

            //foreach (var item in set)
            //    Console.WriteLine(item);
            #endregion

            #region Let / Into


            //aeiouAEIOU

            //List<string> Names = new List<string>() { "Ahmed" ,"Mona" ,"Mahmoud","Moamen","Sally"};

            //var Result = from N in Names
            //             select Regex.Replace(N, "[aeiouAEIOU]", string.Empty)
            //             //into : Restart Query With Introducing New Range Variable(NoVolName)
            //             into NoVolName
            //             where NoVolName.Length > 3
            //             select NoVolName;


            //Result = from N in Names
            //         let NoVolName = Regex.Replace(N, "[aeiouAEIOU]", string.Empty)
            //         //Let : Continue Query With Adding New Range Variable(NoVolName)
            //         where NoVolName.Length > 3
            //         select NoVolName;

            //Result = Names.Select(N => Regex.Replace(N, "[aeiouAEIOU]", string.Empty))
            //              .Where(NoVolName => NoVolName.Length > 3);

            //foreach (var Name in Result)
            //    Console.WriteLine(Name);
            #endregion

        }
    }
}