const countries = [
    { CountryID: 1, CountryName: "India" },
    { CountryID: 2, CountryName: "USA" },
    { CountryID: 3, CountryName: "Canada" },
    { CountryID: 4, CountryName: "Australia" },
    { CountryID: 5, CountryName: "Germany" },
    { CountryID: 6, CountryName: "France" },
    { CountryID: 7, CountryName: "Japan" },
    { CountryID: 8, CountryName: "China" },
    { CountryID: 9, CountryName: "Brazil" },
    { CountryID: 10, CountryName: "Russia" },
    { CountryID: 11, CountryName: "South Africa" },
    { CountryID: 12, CountryName: "Mexico" },
    { CountryID: 13, CountryName: "Italy" },
    { CountryID: 14, CountryName: "Spain" },
    { CountryID: 15, CountryName: "South Korea" },
    { CountryID: 16, CountryName: "United Kingdom" },
    { CountryID: 17, CountryName: "Argentina" },
    { CountryID: 18, CountryName: "Netherlands" },
    { CountryID: 19, CountryName: "Sweden" },
    { CountryID: 20, CountryName: "Switzerland" },
  ];
  
  const states = [
    { StateID: 1, StateName: "Gujarat", CountryID: 1 },
    { StateID: 2, StateName: "Maharashtra", CountryID: 1 },
    { StateID: 3, StateName: "Texas", CountryID: 2 },
    { StateID: 4, StateName: "California", CountryID: 2 },
    { StateID: 5, StateName: "Ontario", CountryID: 3 },
    { StateID: 6, StateName: "Quebec", CountryID: 3 },
    { StateID: 7, StateName: "New South Wales", CountryID: 4 },
    { StateID: 8, StateName: "Queensland", CountryID: 4 },
    { StateID: 9, StateName: "Bavaria", CountryID: 5 },
    { StateID: 10, StateName: "Hessen", CountryID: 5 },
    { StateID: 11, StateName: "Île-de-France", CountryID: 6 },
    { StateID: 12, StateName: "Normandy", CountryID: 6 },
    { StateID: 13, StateName: "Tokyo", CountryID: 7 },
    { StateID: 14, StateName: "Osaka", CountryID: 7 },
    { StateID: 15, StateName: "Beijing", CountryID: 8 },
    { StateID: 16, StateName: "Shanghai", CountryID: 8 },
    { StateID: 17, StateName: "São Paulo", CountryID: 9 },
    { StateID: 18, StateName: "Rio de Janeiro", CountryID: 9 },
    { StateID: 19, StateName: "Moscow", CountryID: 10 },
    { StateID: 20, StateName: "Saint Petersburg", CountryID: 10 },
  ];
  
  const cities = [
    { CityID: 1, CityName: "Rajkot", StateID: 1, CountryID: 1 },
    { CityID: 2, CityName: "Ahmedabad", StateID: 1, CountryID: 1 },
    { CityID: 3, CityName: "Mumbai", StateID: 2, CountryID: 1 },
    { CityID: 4, CityName: "Pune", StateID: 2, CountryID: 1 },
    { CityID: 5, CityName: "Houston", StateID: 3, CountryID: 2 },
    { CityID: 6, CityName: "Dallas", StateID: 3, CountryID: 2 },
    { CityID: 7, CityName: "Los Angeles", StateID: 4, CountryID: 2 },
    { CityID: 8, CityName: "San Francisco", StateID: 4, CountryID: 2 },
    { CityID: 9, CityName: "Toronto", StateID: 5, CountryID: 3 },
    { CityID: 10, CityName: "Ottawa", StateID: 5, CountryID: 3 },
    { CityID: 11, CityName: "Montreal", StateID: 6, CountryID: 3 },
    { CityID: 12, CityName: "Quebec City", StateID: 6, CountryID: 3 },
    { CityID: 13, CityName: "Sydney", StateID: 7, CountryID: 4 },
    { CityID: 14, CityName: "Newcastle", StateID: 7, CountryID: 4 },
    { CityID: 15, CityName: "Brisbane", StateID: 8, CountryID: 4 },
    { CityID: 16, CityName: "Gold Coast", StateID: 8, CountryID: 4 },
    { CityID: 17, CityName: "Munich", StateID: 9, CountryID: 5 },
    { CityID: 18, CityName: "Nuremberg", StateID: 9, CountryID: 5 },
    { CityID: 19, CityName: "Frankfurt", StateID: 10, CountryID: 5 },
    { CityID: 20, CityName: "Darmstadt", StateID: 10, CountryID: 5 },
  ];
  
