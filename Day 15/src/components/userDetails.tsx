import React from 'react';
import { Box, Typography, Grid, Paper } from '@mui/material';
import { MapPin, Users, Cake, BarChart2, Home } from 'lucide-react';
import { User } from '../Types/User';

interface UserDetailsProps {
    user: User;
}

const UserDetails: React.FC<UserDetailsProps> = ({ user }) => {
    const DetailItem = ({ icon, title, value }: { icon: React.ReactNode, title: string, value: string | string[] }) => {
        return (
            <Box sx={{ display: 'flex', alignItems: 'flex-start', gap: 1.5, mb: 2 }}>
                <Box sx={{ 
                    display: 'flex', 
                    alignItems: 'center', 
                    justifyContent: 'center',
                    color: 'primary.main',
                    p: 1,
                    minWidth: 36,
                    height: 36
                    }}>
                    {icon}
                </Box>
                <Box>
                <Typography variant="body2" color="text.secondary">
                    {title}
                </Typography>
                {Array.isArray(value) ? (
                    value.map((item, index) => (
                    <Typography key={index} variant="body2" fontWeight={500}>
                        {item}
                    </Typography>
                    ))
                ) : (
                    <Typography variant="body2" fontWeight={500}>
                    {value}
                    </Typography>
                )}
                </Box>
            </Box>
        );
    };

    return (
        <Paper elevation={0} sx={{ p: 2}}>
        <Grid container spacing={3}>
            <Grid >
                <DetailItem 
                    icon={<MapPin size={18} />} 
                    title="Office Location" 
                    value={user.officeLocation} 
                />
            </Grid>
            <Grid >
            <DetailItem 
                icon={<Users size={18} />} 
                title="Team Mates" 
                value={user.teamMates} 
            />
            </Grid>
            <Grid>
                <DetailItem 
                    icon={<Cake size={18} />} 
                    title="Birthday" 
                    value={user.birthday} 
                />
            </Grid>
            <Grid >
                <DetailItem 
                    icon={<BarChart2 size={18} />} 
                    title="HR Year" 
                    value={user.hrYear} 
                />
            </Grid>
            <Grid >
                <DetailItem 
                    icon={<Home size={18} />} 
                    title="Address" 
                    value={user.address} 
                />
            </Grid>
        </Grid>
        </Paper>
    );
};

export default UserDetails;