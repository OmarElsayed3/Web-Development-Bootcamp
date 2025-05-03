import React from 'react';
import { Avatar } from '@mui/material';

interface UserAvatarProps {
    src: string;
    name: string;
    size?: 'small' | 'medium' | 'large';
}

const UserAvatar: React.FC<UserAvatarProps> = ({ src, name, size = 'medium' }) => {
const getSizeValue = () => {
    switch (size) {
    case 'small':
        return { width: 32, height: 32 };
    case 'large':
        return { width: 56, height: 56 };
    case 'medium':
    default:
        return { width: 40, height: 40 };
    }
};

const sizeStyles = getSizeValue();

return (
    <Avatar 
    src={src} 
    alt={name} 
    sx={{
        ...sizeStyles,
        border: '2px solid #fff',
        boxShadow: '0 0 0 1px rgba(0, 0, 0, 0.08)'
    }}
    >
    {name.split(' ').map(n => n[0]).join('')}
    </Avatar>
);
};

export default UserAvatar;