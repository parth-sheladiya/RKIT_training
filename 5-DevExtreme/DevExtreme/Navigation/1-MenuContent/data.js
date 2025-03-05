const foodData = [
  {
    id: "1",
    name: "Beverages",
    icon: "fas fa-coffee",
    expanded: true,
    items: [
      {
        id: "1_1",
        name: "Cappuccino",
        price: 3.5,
        icon: "fas fa-coffee",
       
        
      },
      {
        id: "1_2",
        name: "Iced Tea",
        price: 2.5,
        icon: "fas fa-cocktail",
      },
      {
        id: "1_3",
        name: "Lemonade",
        price: 2,
        icon: "fas fa-lemon",
        disabledExpr:function(){
            return this.price>1
        }
      },
    ],
  },
  {
    id: "2",
    name: "Main Courses",
    icon: "fas fa-pizza-slice",
    hasItems: true,
    items: [
      {
        id: "2_1",
        name: "Spaghetti Bolognese",
        icon: "fas fa-utensils",
        price: 12.5,
      },
      {
        id: "2_2",
        name: "Grilled Chicken",
        icon: "fas fa-drumstick-bite",
        price: 14.5,
        disabled:true
      },
      {
        id: "2_3",
        name: "Vegetable Stir Fry",
        icon: "fas fa-pepper-hot",
        price: 10.0,
      },
      {
        id: "2_4",
        name: "Cheese Burger",
        icon: "fas fa-hamburger",
        price: 8.0,
      },
    ],
  },
  {
    id: "3",
    name: "Appetizers",
    icon: "fas fa-french-fries",
    items: [
      {
        id: "3_1",
        name: "Garlic Bread",
        icon: "fas fa-bread-slice",
        price: 4.0,
        disabled:true
      },
      {
        id: "3_2",
        name: "Chicken Wings",
        icon: "fas fa-drumstick-bite",
        price: 7.5,
      },
      {
        id: "3_3",
        name: "Mozzarella Sticks",
        icon: "fas fa-cheese",
        price: 6.0,
      },
    ],
  },
  {
    id: "4",
    name: "Desserts",
    icon: "fas fa-ice-cream",
    items: [
      {
        id: "4_1",
        name: "Chocolate Cake",
        icon: "fas fa-cake",
        price: 5.0,
      },
      {
        id: "4_2",
        name: "Ice Cream Sundae",
        icon: "fas fa-ice-cream",
        price: 4.5,
      },
      {
        id: "4_3",
        name: "Apple Pie",
        icon: "fas fa-pie",
        price: 3.0,
      },
    ],
  },
  {
    id: "5",
    name: "Salads",
    icon: "fas fa-leaf",
    items: [
      {
        id: "5_1",
        name: "Caesar Salad",
        icon: "fas fa-leaf",
        price: 7.0,
      },
      {
        id: "5_2",
        name: "Greek Salad",
        icon: "fas fa-leaf",
        price: 6.5,
      },
      {
        id: "5_3",
        name: "Cobb Salad",
        icon: "fas fa-leaf",
        price: 8.0,
      },
    ],
  },
  {
    id: "6",
    name: "Snacks",
    icon: "fas fa-corn",
    items: [
      {
        id: "6_1",
        name: "Popcorn",
        icon: "fas fa-corn",
        price: 2.5,
      },
      {
        id: "6_2",
        name: "Chips",
        icon: "fas fa-bacon",
        price: 2.0,
      },
      {
        id: "6_3",
        name: "Nuts Mix",
        icon: "fas fa-seedling",
        price: 3.0,
      },
    ],
  },
  {
    id: "7",
    name: "Side Dishes",
    icon: "fas fa-plate",
    items: [
      {
        id: "7_1",
        name: "Mashed Potatoes",
        icon: "fas fa-potato",
        price: 4.0,
      },
      {
        id: "7_2",
        name: "Coleslaw",
        icon: "fas fa-lemon",
        price: 3.5,
      },
      {
        id: "7_3",
        name: "Rice Pilaf",
        icon: "fas fa-rice",
        price: 3.0,
      },
    ],
  },
  {
    id: "8",
    name: "Sandwiches",
    icon: "fas fa-bread-slice",
    items: [
      {
        id: "8_1",
        name: "Chicken Sandwich",
        icon: "fas fa-bread-slice",
        price: 7.0,
      },
      {
        id: "8_2",
        name: "Grilled Cheese",
        icon: "fas fa-bread-slice",
        price: 5.0,
      },
      {
        id: "8_3",
        name: "Vegetarian Sandwich",
        icon: "fas fa-bread-slice",
        price: 6.0,
      },
    ],
  },
  {
    id: "9",
    name: "Pizza",
    icon: "fas fa-pizza-slice",
    items: [
      {
        id: "9_1",
        name: "Margherita",
        icon: "fas fa-pizza-slice",
        price: 10.0,
      },
      {
        id: "9_2",
        name: "Pepperoni",
        icon: "fas fa-pizza-slice",
        price: 12.0,
      },
      {
        id: "9_3",
        name: "Veggie Supreme",
        icon: "fas fa-pizza-slice",
        price: 11.0,
      },
    ],
  },
  {
    id: "10",
    name: "Smoothies",
    icon: "fas fa-blender",
    items: [
      {
        id: "10_1",
        name: "Mango Smoothie",
        icon: "fas fa-blender",
        price: 5.5,
      },
      {
        id: "10_2",
        name: "Berry Smoothie",
        icon: "fas fa-blender",
        price: 5.0,
      },
      {
        id: "10_3",
        name: "Green Smoothie",
        icon: "fas fa-blender",
        price: 4.5,
      },
    ],
  },
];
