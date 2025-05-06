import React, { useState } from 'react';
import { 
    Table, 
    TableBody, 
    TableCell, 
    TableContainer, 
    TableHead, 
    TableRow, 
    Paper, 
    Checkbox, 
    Box, 
    IconButton,
    Collapse, 
    Typography,
    Pagination,
    Chip,
    Skeleton 
} from '@mui/material';
import { ChevronDown, ChevronUp, Edit2, Trash2 } from 'lucide-react';
import UserAvatar from './userAvatar';
import UserDetails from './userDetails';
import UserTableHeader from './tableHeader';
import { useTeamMembers } from '../service/reactQuery';

const UserTable: React.FC = () => {
    const [currentPage, setCurrentPage] = useState(1);
    const rowsPerPage = 10;
    const [searchQuery, setSearchQuery] = useState('');
    const [selectedUsers, setSelectedUsers] = useState<string[]>([]);
    const [expandedUser, setExpandedUser] = useState<string | null>(null);

    const { users, isLoading, isError, totalCount } = useTeamMembers(currentPage, rowsPerPage, searchQuery);

    const handleSelectUser = (userId: string) => {
        const selectedIndex = selectedUsers.indexOf(userId);
        let newSelected: string[] = [];
        if (selectedIndex === -1) {
            newSelected = [...selectedUsers, userId];
        } else {
            newSelected = selectedUsers.filter(id => id !== userId);
        }
        setSelectedUsers(newSelected);
    };

    const handleExpandUser = (userId: string) => {
        setExpandedUser(expandedUser === userId ? null : userId);
    };

    const handlePageChange = (_event: React.ChangeEvent<unknown>, value: number) => {
        setCurrentPage(value);
    };

    if (isError) {
        return <Typography>Error loading users</Typography>;
    }

    return (
        <Box sx={{ width: '100%', overflow: 'hidden' }}>
            <UserTableHeader 
                searchQuery={searchQuery} 
                setSearchQuery={setSearchQuery} 
            />
        
            <Paper sx={{ 
                width: '100%', 
                mb: 2, 
                borderRadius: 3,
                overflow: 'hidden',
                boxShadow: '0 2px 10px rgba(0,0,0,0.05)'
            }}>
                <TableContainer>
                    <Table>
                        <TableHead sx={{ backgroundColor: 'rgba(0, 0, 0, 0.02)' }}>
                            <TableRow>
                                <TableCell padding="checkbox">
                                    <Checkbox 
                                        color="primary"
                                        indeterminate={selectedUsers.length > 0 && selectedUsers.length < users.length}
                                        checked={users.length > 0 && selectedUsers.length === users.length}
                                        onChange={(event) => {
                                            if (event.target.checked) {
                                                setSelectedUsers(users.map(user => user.id));
                                            } else {
                                                setSelectedUsers([]);
                                            }
                                        }}
                                    />
                                </TableCell>
                                <TableCell>
                                    <Typography variant="body2" fontWeight={600}>
                                        Name
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography variant="body2" fontWeight={600}>
                                        Position
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography variant="body2" fontWeight={600}>
                                        Department
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography variant="body2" fontWeight={600}>
                                        Email
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography variant="body2" fontWeight={600}>
                                        Phone
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography variant="body2" fontWeight={600}>
                                        Status
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography variant="body2" fontWeight={600}>
                                        Edit
                                    </Typography>
                                </TableCell>
                                <TableCell width={20} />
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {isLoading ? (
                                Array.from({ length: rowsPerPage }).map((_, index) => (
                                    <TableRow key={index}>
                                        <TableCell padding="checkbox">
                                            <Skeleton variant="rectangular" width={24} height={24} />
                                        </TableCell>
                                        <TableCell>
                                            <Skeleton variant="text" width="80%" />
                                        </TableCell>
                                        <TableCell>
                                            <Skeleton variant="text" width="60%" />
                                        </TableCell>
                                        <TableCell>
                                            <Skeleton variant="text" width="70%" />
                                        </TableCell>
                                        <TableCell>
                                            <Skeleton variant="text" width="50%" />
                                        </TableCell>
                                        <TableCell>
                                            <Skeleton variant="text" width="40%" />
                                        </TableCell>
                                        <TableCell>
                                            <Skeleton variant="text" width="50%" />
                                        </TableCell>
                                        <TableCell>
                                            <Skeleton variant="rectangular" width={24} height={24} />
                                        </TableCell>
                                    </TableRow>
                                ))
                            ) : (
                                users.map((user) => {
                                    const isSelected = selectedUsers.includes(user.id);
                                    const isExpanded = expandedUser === user.id;

                                    return (
                                        <React.Fragment key={user.id}>
                                            <TableRow 
                                                hover
                                                selected={isSelected}
                                                sx={{
                                                    cursor: 'pointer',
                                                    '&.Mui-selected': {
                                                        backgroundColor: 'rgba(25, 118, 210, 0.08)',
                                                    },
                                                    '&.MuiTableRow-hover:hover': {
                                                        backgroundColor: 'rgba(0, 0, 0, 0.04)',
                                                    },
                                                }}
                                            >
                                                <TableCell padding="checkbox">
                                                    <Checkbox
                                                        color="primary"
                                                        checked={isSelected}
                                                        onClick={(event) => event.stopPropagation()}
                                                        onChange={() => handleSelectUser(user.id)}
                                                    />
                                                </TableCell>
                                                <TableCell 
                                                    component="th" 
                                                    scope="row"
                                                    sx={{ 
                                                        display: 'flex', 
                                                        alignItems: 'center',
                                                    }}
                                                >
                                                    <IconButton 
                                                        size="small" 
                                                        onClick={() => handleExpandUser(user.id)}
                                                        sx={{ 
                                                            marginLeft: -1,
                                                            transition: 'transform 0.2s',
                                                            transform: isExpanded ? 'rotate(180deg)' : 'rotate(0deg)'
                                                        }}
                                                    >
                                                        {isExpanded ? <ChevronUp size={18} /> : <ChevronDown size={18} />}
                                                    </IconButton>
                                                    <UserAvatar src={user.avatar} name={user.name} />
                                                    <Typography variant="body2" fontWeight={500}>{user.name}</Typography>
                                                </TableCell>
                                                <TableCell >
                                                    <Typography variant="body2">{user.position}</Typography>
                                                </TableCell>
                                                <TableCell >
                                                    <Typography variant="body2">{user.department}</Typography>
                                                </TableCell>
                                                <TableCell >
                                                    <Typography variant="body2">{user.email}</Typography>
                                                </TableCell>
                                                <TableCell >
                                                    <Typography variant="body2">{user.phone}</Typography>
                                                </TableCell>
                                                <TableCell >
                                                    {user.status === 'Full Time' ? (
                                                        <Chip
                                                            label="Full Time"
                                                            color="success"
                                                            variant="outlined"
                                                            sx={{
                                                                backgroundColor: 'rgba(46, 204, 113, 0.1)',
                                                                borderColor: 'rgba(46, 204, 113, 0.3)',
                                                                color: 'rgb(46, 204, 113)',
                                                                fontWeight: 500,
                                                                fontSize: '0.75rem'
                                                            }}
                                                        />
                                                    ) : user.status === 'Part Time' ? (
                                                        <Chip
                                                            label="Part Time"
                                                            color="warning"
                                                            variant="outlined"
                                                            sx={{
                                                                backgroundColor: 'rgba(241, 196, 15, 0.1)',
                                                                borderColor: 'rgba(241, 196, 15, 0.3)',
                                                                color: 'rgb(241, 196, 15)',
                                                                fontWeight: 500,
                                                                fontSize: '0.75rem'
                                                            }}
                                                        />
                                                    ) : null}
                                                    
                                                </TableCell>
                                                <TableCell>
                                                    <Box sx={{ display: 'flex', gap: 1 }}>
                                                        <IconButton size="small" sx={{ color: 'primary.main' }}>
                                                            <Edit2 size={16} />
                                                        </IconButton>
                                                        <IconButton size="small" sx={{ color: 'error.main' }}>
                                                            <Trash2 size={16} />
                                                        </IconButton>
                                                    </Box>
                                                </TableCell>
                                            </TableRow>
                                            <TableRow>
                                                <TableCell 
                                                    colSpan={5} 
                                                    sx={{ 
                                                        py: 0, 
                                                        borderBottom: isExpanded ? '1px solid rgba(224, 224, 224, 1)' : 'none'
                                                    }}
                                                >
                                                    <Collapse in={isExpanded} timeout="auto" unmountOnExit>
                                                        <Box sx={{ py: 2 }}>
                                                            <UserDetails user={user} />
                                                        </Box>
                                                    </Collapse>
                                                </TableCell>
                                            </TableRow>
                                        </React.Fragment>
                                    );
                                })
                            )}
                        </TableBody>
                    </Table>
                </TableContainer>
                
                <Box sx={{ 
                    display: 'flex', 
                    justifyContent: 'space-between', 
                    alignItems: 'center',
                    px: 2,
                    py: 1.5,
                    borderTop: '1px solid rgba(224, 224, 224, 1)'
                }}>
                    <Typography variant="body2" color="text.secondary">
                        {currentPage} - {currentPage} of {Math.ceil(totalCount / rowsPerPage)}
                    </Typography>
                    <Pagination 
                        count={Math.ceil(totalCount / rowsPerPage)} 
                        page={currentPage} 
                        onChange={handlePageChange}
                        color="primary"
                        size="small"
                        shape="rounded"
                    />
                </Box>
            </Paper>
        </Box>
    );
};

export default UserTable;