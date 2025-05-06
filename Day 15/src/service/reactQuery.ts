import { useQuery } from '@tanstack/react-query';
import { User } from '../Types/User';
import { fetchUsers } from '../api/userApi';

export const useTeamMembers = (page: number, rowsPerPage: number, searchTerm: string) => {
    const { data: users = [], isLoading, isError, error } = useQuery<User[], Error>({
        queryKey: ['users', page, rowsPerPage, searchTerm],
        queryFn: async () => {
            const users = await fetchUsers(page, rowsPerPage);
            return users.filter(user => 
                user.name.toLowerCase().includes(searchTerm.toLowerCase())
            );
        },
        staleTime: 5 * 60 * 1000,
        retry: 3,
    });

    const totalCount = 100;

    return {
        users,
        totalCount,
        isLoading,
        isError,
        error,
    };
};