use mts
db.Dish.aggregate([
    {
        $lookup: {
            from: "Image",
            localField: "IdImage",    // field in the orders collection
            foreignField: "_id",  // field in the items collection
            as: "IdImage"
        },
    },
    { $set: { Image: "$IdImage" } },
    { $out: { db: "mts", coll: "Dish" } },
])
db.Image.drop(),

    db.DishCategory.aggregate([
        {
            $lookup: {
                from: "Category",
                localField: "IdCategory",
                foreignField: "_id",
                as: "Category"
            }
        },

        { $out: { db: "mts", coll: "DishCategory" } },

    ])

db.Category.drop(),


    db.Dish.aggregate([
        {
            $lookup: {
                from: "DishCategory",
                localField: "_id",
                foreignField: "IdDish",
                as: "Category"
            }
        },
        { $set: { Category: "$Category.Category" } },
        { $out: { db: "mts", coll: "Dish" } },
    ])
db.DishCategory.drop()
db.Dish.updateMany({}, { "$unset": { "IdImage": "" } })
db.Dish.aggregate([{
    $unwind: {
        path: '$Image'
    }
}, {
    $out: 'Dish'
}])
var collectDishCategoriesPipeline = [
    {$unwind: {path: "$Category", preserveNullAndEmptyArrays: true}},
    {$unwind: "$Category"},
    {$group: {_id: {id: "$_id", Name: "$Name", Description: "$Description", Price: "$Price", Image: "$Image"}, "CategoriesArr": {$push: "$Category"}}},
    {$project: {
        _id: "$_id.id",
        Name: "$_id.Name",
        Description: "$_id.Description",
        Price: "$_id.Price",
        Image: "$_id.Image",
        Category: "$CategoriesArr"}},
    {$sort: {_id: 1, Name: -1}},
    {$out: "Dish"}
]    
db.Dish.aggregate(collectDishCategoriesPipeline)
