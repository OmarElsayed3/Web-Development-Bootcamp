import React from 'react';
import { 
    Box, 
    TextField, 
    Button, 
    Typography, 
    Checkbox,
    InputAdornment
} from '@mui/material';
import { Search, Plus } from 'lucide-react';
import { useUserContext } from './contextUser';

const UserTableHeader: React.FC = () => {
    const { users, selectedUsers, setSelectedUsers, searchQuery, setSearchQuery } = useUserContext();

    const handleSelectAll = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.checked) {
        setSelectedUsers(users.map(user => user.id));
        } else {
        setSelectedUsers([]);
        }
    };

    const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setSearchQuery(event.target.value);
    };

    const isAllSelected = users.length > 0 && selectedUsers.length === users.length;
    const isSomeSelected = selectedUsers.length > 0 && selectedUsers.length < users.length;

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

export default UserTableHeader