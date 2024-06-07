export type User = {
    id:string;
    firstName: string;
    lastName: string;
    email: string;
    avatarURL : string;
    numberPhone: string;
    address: string;
};

export type UserRequest = {
    firstName: string;
    lastName: string;
    email: string;
    numberPhone: string;
    address: string;
};