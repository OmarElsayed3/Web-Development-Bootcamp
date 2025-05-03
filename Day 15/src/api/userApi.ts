import axios from 'axios';
import { User, UserResponse } from '../Types/User';
import { format } from 'date-fns';

// Array of possible positions for random assignment
const positions = [
    'Graphics Designer',
    'UI/UX Designer',
    'Frontend Developer',
    'Backend Developer',
    'Full Stack Developer',
    'Product Manager',
    'Marketing Specialist',
    'HR Specialist',
    'Content Writer',
    'Data Analyst',
    'Python Developer',
    'Java Developer',
    'QA Engineer',
    'DevOps Engineer',
    'CTO',
    'CEO',
    'Sales Manager',
    'Customer Success'
];

// Array of possible departments for random assignment
const departments = [
    'Engineering',
    'Marketing',
    'Sales',
    'Human Resources',
    'Product',
    'Design',
    'Customer Success',
    'Operations',
    'Management',
    'Finance'
];



const transformUserData = (data: UserResponse): User[] => {
    return data.results.map(user => {
        const teammates: string[] = [];
        const randomPosition = positions[Math.floor(Math.random() * positions.length)];
        const randomDepartment = departments[Math.floor(Math.random() * departments.length)];
        const status = Math.random() > 0.3 ? 'Full Time' : 'Part Time';
        const hrYears = Math.floor(Math.random() * 10) + 1;

        return {
            id: user.login.uuid,
            name: `${user.name.first} ${user.name.last}`,
            avatar: user.picture.medium,
            position: randomPosition,
            department: randomDepartment,
            email: user.email,
            phone: user.phone,
            status: status,
            officeLocation: `${Math.floor(Math.random() * 9000) + 1000} ${user.location.street.name}, ${user.location.city}, ${user.location.state} ${user.location.postcode}`,
            teamMates: teammates,
            birthday: format(new Date(user.dob.date), 'MM/dd/yyyy'),
            hrYear: `${hrYears} ${hrYears === 1 ? 'Year' : 'Years'}`,
            address: `${user.location.street.number} ${user.location.street.name}, ${user.location.city}, ${user.location.state} ${user.location.postcode}`
        };
    });
};

export const fetchUsers = async (page = 1, results = 10): Promise<User[]> => {
    try {
        const response = await axios.get<UserResponse>(`https://randomuser.me/api?page=${page}&results=${results}&seed=abc123`);
        return transformUserData(response.data);
    } catch (error) {
        console.error('Error fetching users:', error);
        return [];
    }
};