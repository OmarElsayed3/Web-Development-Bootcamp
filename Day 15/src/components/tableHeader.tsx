import React, { useState } from 'react';
import { 
    Box, 
    TextField, 
    Button, 
    Typography, 
    Checkbox,
    InputAdornment
} from '@mui/material';
import { Search, Plus } from 'lucide-react';
import { useTeamMembers } from '../service/reactQuery';

const UserTableHeader: React.FC = () => {
    const [searchQuery, setSearchQuery] = useState('');
    const [currentPage, setCurrentPage] = useState(1);
    const rowsPerPage = 10;

    // Use React Query to fetch users
    const { users, isLoading, isError } = useTeamMembers(currentPage, rowsPerPage, searchQuery);

    const [selectedUsers, setSelectedUsers] = useState<string[]>([]);

    const handleSelectAll = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.checked) {
            setSelectedUsers(users?.map(user => user.id) || []); // Ensure users is not undefined
        } else {
            setSelectedUsers([]);
        }
    };

    const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setSearchQuery(event.target.value);
    };

    const isAllSelected = users?.length > 0 && selectedUsers.length === users.length;
    const isSomeSelected = selectedUsers.length > 0 && selectedUsers.length < (users?.length || 0);

    if (isLoading) {
        return <Typography>Loading...</Typography>;
    }

    if (isError) {
        return <Typography>Error loading users</Typography>;
    }

    return (
        <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', mb: 2 }}>
            <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
                <TextField
                    placeholder="Search Task"
                    size="small"
                    value={searchQuery}
                    onChange={handleSearchChange}
                    sx={{ 
                        width: { xs: '100%', sm: 240 },
                        '.MuiOutlinedInput-root': {
                            borderRadius: 2,
                            backgroundColor: 'rgba(0, 0, 0, 0.02)',
                            transition: 'all 0.2s ease-in-out',
                            '&:hover': {
                                backgroundColor: 'rgba(0, 0, 0, 0.04)',
                            },
                            '&.Mui-focused': {
                                backgroundColor: 'white',
                            }
                        }
                    }}
                    InputProps={{
                        startAdornment: (
                            <InputAdornment position="start">
                                <Search size={18} />
                            </InputAdornment>
                        ),
                    }}
                />
                
                {selectedUsers.length > 0 && (
                    <Box sx={{ display: 'flex', alignItems: 'center' }}>
                        <Checkbox
                            checked={isAllSelected}
                            indeterminate={isSomeSelected}
                            onChange={handleSelectAll}
                            size="small"
                        />
                        <Typography variant="body2" sx={{ fontWeight: 500 }}>
                            {selectedUsers.length} Selected
                        </Typography>
                    </Box>
                )}
            </Box>

            <Button 
                variant="contained" 
                color="primary" 
                startIcon={<Plus size={18} />}
                sx={{ 
                    borderRadius: 2,
                    textTransform: 'none',
                    boxShadow: 2,
                    py: 1,
                    px: 2
                }}
            >
                Add User
            </Button>
        </Box>
    );
};

export default UserTableHeader;