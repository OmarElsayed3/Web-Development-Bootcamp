export interface User {
    id: string;
    name: string;
    avatar: string;
    position: string;
    department: string;
    email: string;
    phone: string;
    status: 'Full Time' | 'Part Time';
    officeLocation: string;
    teamMates: string[];
    birthday: string;
    hrYear: string;
    address: string;
}
export interface UserResponse {
    results: Array<{
        login: { uuid: string };
        name: { first: string; last: string };
        email: string;
        phone: string;
        picture: { large: string; medium: string; thumbnail: string };
        location: {
        street: { number: number; name: string };
        city: string;
        state: string;
        postcode: string;
        coordinates: { latitude: string; longitude: string };
        };
        dob: { date: string; age: number };
        registered: { date: string; age: number };
    }>;
    info: {
        seed: string;
        results: number;
        page: number;
        version: string;
    };
}