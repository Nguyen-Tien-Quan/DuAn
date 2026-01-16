using DuAnThucTap_vs.Models;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Categories.Any()) return;

        var cat1 = new Category
        {
            CategoryName = "Chẩn đoán hình ảnh",
            Slug = "chan-doan-hinh-anh",
            IsActive = true
        };

        var cat2 = new Category
        {
            CategoryName = "Hồi sức cấp cứu",
            Slug = "hoi-suc-cap-cuu",
            IsActive = true
        };

        context.Categories.AddRange(cat1, cat2);
        context.SaveChanges();

        var brand = new Brand
        {
            BrandName = "GE Healthcare",
            Country = "USA",
            IsActive = true
        };

        context.Brands.Add(brand);
        context.SaveChanges();

        context.Products.AddRange(
            new Product
            {
                ProductName = "Máy siêu âm màu 4D",
                CategoryId = cat1.CategoryId,
                BrandId = brand.BrandId,
                IsActive = true
            },
            new Product
            {
                ProductName = "Máy X-Quang kỹ thuật số",
                CategoryId = cat1.CategoryId,
                BrandId = brand.BrandId,
                IsActive = true
            }
        );

        context.SaveChanges();
    }
}
