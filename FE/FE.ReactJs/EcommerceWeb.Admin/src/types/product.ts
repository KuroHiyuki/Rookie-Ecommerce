

export type Product = {
  id: string
  name: string;
  category: string;
  description: string;
  price: number;
  image: string;
  CreatedDate: string;
  UpdatedDate: string;
  Inventory: number;
};

export type ProductRequest = {
	name: string;
	description: string;
	price: number;
	inventory: number;
  categoryId: string;
  imgUrls: string[];
	CreatedDate: string;
	updatedAt: string;
};
