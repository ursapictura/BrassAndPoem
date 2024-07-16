
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using BrassAndPoem;

List<Product> products = new List<Product>()
{
    new Product("The Penguin Anthology of Twentieth-Century American Poetry", 30.00M, 1),
    new Product("Breaking Lorca: Fourteen Poems of Love and Death", 11, 1),
    new Product("french horn", 450, 2),
    new Product("saxophone", 350, 2),
    new Product("Adrienne Rich: Poetry and Prose: A Norton Critical Edition", 30.61M, 1)
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType("poetry", 1),
    new ProductType("brass instrument", 2),
};
//put your greeting here

string greeting = "Welcome to Brass and Poems, a shop devoted to both written and instrumental rhythm.";

Console.WriteLine(greeting);
//implement your loop here
string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Clear();
        DisplayAllProducts(products, productTypes);
    }
    else if (choice == "2")
    {
        Console.Clear();
        DeleteProduct(products, productTypes);
    }
    else if (choice == "3")
    {
        Console.Clear();
        AddProduct(products, productTypes);
    }
    else if (choice == "4")
    {
        Console.Clear();
        UpdateProduct(products, productTypes);
    }
    else if (choice == "5")
    {
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Sorry, your input was not valid. Please select a number between 1 - 5.");
    }
}

void DisplayMenu()
{
    Console.WriteLine(@"
What would you like to do today?
1. View all products
2. Delete a product
3. Add a product
4. Update a product
5. Exit
");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} in the {productTypes.FirstOrDefault(p => p.Id == products[i].ProductTypeId).Title} category is available for {products[i].Price}.");
    };
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter the number of the product you would like to remove.");
    DisplayAllProducts(products, productTypes);

    while (true)
    {
        if (Int32.TryParse(Console.ReadLine(), out int productNumber)
            && productNumber > 0
            && productNumber <= products.Count)
        {
            int productIndex = productNumber - 1;
            Console.WriteLine($"{products[productIndex].Name} has been deleted.");
            products.RemoveAt(productIndex);
            break;
        }
        else
        {
            Console.WriteLine("Your input was not valid. Please select the NUMBER which cooresponds to the product you would like to delete.");
        }
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    string productName = null;
    while(string.IsNullOrEmpty(productName))
    {
        Console.WriteLine("What is the name of the product you would like to add?");
        productName = Console.ReadLine();

    }

    decimal productPrice;
    while(true)
    {
        Console.WriteLine($"What is the price of {productName}?");

        if (decimal.TryParse(Console.ReadLine(), out productPrice))
        {
            break;
        }
        else{
            Console.WriteLine($"I'm sorry, but that input was not valid. Please enter the numerical price of {productName}");
        }
    }

    int productTypeId;
    while(true)
    {
        Console.WriteLine(@$"Which cateogry would you like {productName} sorted into?
        1. poetry
        2. brass instruments");

        if(Int32.TryParse(Console.ReadLine(), out productTypeId))
        {
            break;
        }
        else if (Console.ReadLine().ToLower().Equals("poetry"))
        {
            productTypeId = 1;
        }
        else if (Console.ReadLine().ToLower().Equals("brass")
                || Console.ReadLine().ToLower().Equals("brass instrument")
                || Console.ReadLine().ToLower().Equals("instrument"))
        {
            productTypeId = 2;
        }
        else
        {
            Console.WriteLine($"I'm sorry. but your input was not valid. Please select the number or name of the category you would like {productName} sorted into.");
        }
    }

    Product newProduct = new Product(productName, productPrice, productTypeId);
    products.Add(newProduct);

    Console.WriteLine("${productName} has been added to the Brass and Poems inventory.");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// don't move or change this!
public partial class Program { }