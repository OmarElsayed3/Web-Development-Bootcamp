import { Avatar, Badge, Box, Breadcrumbs, IconButton, Link, Typography } from "@mui/material";
import NotificationsIcon from '@mui/icons-material/Notifications';
import MailOutlineIcon from '@mui/icons-material/MailOutline';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowRightIcon from '@mui/icons-material/KeyboardArrowRight';
import React from "react";

const Header = () => {
    return (
        <Box
            display="flex"
            justifyContent="space-between"
            alignItems="center"
            p={2}
            sx={{ backgroundColor: 'white', borderRadius: 2, boxShadow: 1 }}
            >
            <Box>
                <Typography variant="h6" fontWeight={600}>
                    Team List
                </Typography>
                <Breadcrumbs aria-label="breadcrumb"sx={{ fontSize: 14}} separator={<KeyboardArrowRightIcon fontSize="small"/>}>
                    <Link underline="hover" color="#2082ff" href="#">
                        Admin Dashboard
                    </Link>
                    <Typography color="#666">Team List</Typography>
                </Breadcrumbs>
            </Box>

            <Box display="flex" alignItems="center" gap={1.5} color={'#666'}>
                <IconButton>
                <Badge badgeContent={2} color="error">
                    <NotificationsIcon />
                </Badge>
                </IconButton>
                <IconButton>
                    <MailOutlineIcon />
                </IconButton>
                <Box display="flex" alignItems="center">
                <Avatar
                    src="https://flagcdn.com/us.svg"
                    alt="US Flag"
                    sx={{ width: 24, height: 20}}
                    variant="rounded"
                />
                <KeyboardArrowDownIcon />
                </Box>
            </Box>
        </Box>
    );
}
export default React.memo(Header);