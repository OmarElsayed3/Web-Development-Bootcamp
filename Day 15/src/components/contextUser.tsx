import React, { createContext, useState, useContext, ReactNode } from 'react';
import { User } from '../Types/User';

interface UserContextType {
    users: User[];
    setUsers: React.Dispatch<React.SetStateAction<User[]>>;
    selectedUsers: string[];
    setSelectedUsers: React.Dispatch<React.SetStateAction<string[]>>;
    expandedUser: string | null;
    setExpandedUser: React.Dispatch<React.SetStateAction<string | null>>;
    isLoading: boolean;
    setIsLoading: React.Dispatch<React.SetStateAction<boolean>>;
    currentPage: number;
    setCurrentPage: React.Dispatch<React.SetStateAction<number>>;
    totalPages: number;
    setTotalPages: React.Dispatch<React.SetStateAction<number>>;
    searchQuery: string;
    setSearchQuery: React.Dispatch<React.SetStateAction<string>>;
    filteredUsers: User[];
}

const UserContext = createContext<UserContextType | undefined>(undefined);

export const UserProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
    const [users, setUsers] = useState<User[]>([]);
    const [selectedUsers, setSelectedUsers] = useState<string[]>([]);
    const [expandedUser, setExpandedUser] = useState<string | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [currentPage, setCurrentPage] = useState<number>(1);
    const [totalPages, setTotalPages] = useState<number>(5);
    const [searchQuery, setSearchQuery] = useState<string>('');

    const filteredUsers = users.filter(user => {
        const searchLower = searchQuery.toLowerCase();
        return (
        user.name.toLowerCase().includes(searchLower) ||
        user.email.toLowerCase().includes(searchLower) ||
        user.position.toLowerCase().includes(searchLower) ||
        user.department.toLowerCase().includes(searchLower) ||
        user.phone.toLowerCase().includes(searchLower)
        );
    });

    return (
        <UserContext.Provider
            value={{
                users,
                setUsers,
                selectedUsers,
                setSelectedUsers,
                expandedUser,
                setExpandedUser,
                isLoading,
                setIsLoading,
                currentPage,
                setCurrentPage,
                totalPages,
                setTotalPages,
                searchQuery,
                setSearchQuery,
                filteredUsers
            }}
            >
            {children}
        </UserContext.Provider>
    );
};

// eslint-disable-next-line react-refresh/only-export-components
export const useUserContext = (): UserContextType => {
    const context = useContext(UserContext);
        if (!context) {
            throw new Error('useUserContext must be used within a UserProvider');
        }
    return context;
};