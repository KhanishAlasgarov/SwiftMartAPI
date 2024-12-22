﻿using SwiftMartAPI.Domain.Common;

namespace SwiftMartAPI.Domain.Entities;

public class Product : EntityBase
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int BrandId { get; set; }
    public Brand? Brand { get; set; }
    public required decimal Price { get; set; }
    public required decimal Discount { get; set; }

    public IEnumerable<Category>? Categories { get; set; }


    //public required string ImagePath { get; set; }
}

