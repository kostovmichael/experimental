﻿

namespace PatternsAndConcepts.Services
{

    using DummyModels;

    using System.Collections.Generic;

    public class TestDataGenerator
    {

        public static List<Product> Generate_Large_List_Of_Products()
        {
            var arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();
            int upperBound = arrayOfStrings.Length;
            List<Product> listOfProducts = new List<Product>(upperBound);
            for (int i = 0; i < upperBound; i++)
            {
                listOfProducts.Add(new Product()
                {
                    Id = i + 100,
                    Name = arrayOfStrings[i]
                });
            }

            return listOfProducts;
        }
        public static List<ProductStructLayoutSequential> Generate_Large_List_Of_Product_Structs()
        {
            var arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();
            int upperBound = arrayOfStrings.Length;
            var listOfProducts = new List<ProductStructLayoutSequential>(upperBound);
            for (int i = 0; i < upperBound; i++)
            {
                listOfProducts.Add(new ProductStructLayoutSequential()
                {
                    Id = i + 100,
                    Name = arrayOfStrings[i]
                });
            }
            return listOfProducts;
        }
    }
}