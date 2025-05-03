import { useState } from 'react';
import { Avatar, Box, IconButton, Stack, Tooltip } from '@mui/material';
import {
    CalendarMonthRounded,
    CreditCardRounded,
    DescriptionRounded,
    FolderRounded,
    GridViewRounded,
    GroupsRounded,
    MapRounded,
    SettingsRounded
} from '@mui/icons-material';
import React from 'react';

const Sidebar = () => {
    const [activeIndex, setActiveIndex] = useState(2);
    
    const iconList = [
        { icon: <GridViewRounded />, label: 'Dashboard' },
        { icon: <MapRounded />, label: 'Map' },
        { icon: <GroupsRounded />, label: 'Team' },
        { icon: <DescriptionRounded />, label: 'Documents' },
        { icon: <FolderRounded />, label: 'Folders' },
        { icon: <CreditCardRounded />, label: 'Payments' },
        { icon: <CalendarMonthRounded />, label: 'Calendar' }
    ];

    return (
        <Box
            sx={{
                width: { xs: 60, sm: 70 },
                height: '95%',
                position: 'fixed',
                backgroundColor: 'white',
                border: '1px solid #ddd',
                borderRadius: 5,
                display: 'flex',
                marginLeft: 2,
                flexDirection: 'column',
                alignItems: 'center',
                py: 2,
            }}
        >
            <Box>
                <svg xmlns="http://www.w3.org/2000/svg" width="70" height="80" viewBox="0 0 167 146">
                    <g transform="translate(0,146) scale(0.1,-0.1)" fill="none" stroke="none">
                        <path d="M715 1173 c-72 -39 -88 -117 -36 -175 26 -29 35 -33 81 -33 46 0 55 4 81 33 55 61 31 153 -46 182 -34 13 -44 12 -80 -7z m69 -25 c-3 -4 0 -8 7 -8 23 0 49 -33 49 -62 0 -66 -47 -99 -112 -77 -21 7 -39 19 -39 28 -7 79 -7 81 20 104 26 21 86 33 75 15z" fill="black" />
                        <path d="M1135 1059 c-183 -94 -294 -190 -341 -295 -23 -53 -24 -62 -24 -304 0 -138 3 -250 6 -250 13 0 192 95 243 128 83 55 164 135 196 194 l30 53 5 263 c3 171 2 262 -5 262 -5 0 -55 -23 -110 -51z m93 -216 c-3 -268 -8 -288 -87 -371 -22 -22 -37 -43 -34 -45 2 -3 -5 -8 -17 -12 -12 -4 -34 -20 -50 -37 -16 -16 -32 -29 -37 -29 -4 1 -15 -5 -23 -12 -8 -7 -32 -21 -54 -32 -21 -11 -52 -28 -70 -37 -17 -9 -36 -17 -42 -18 -16 0 -24 111 -18 280 6 190 9 219 22 232 7 7 12 18 12 25 0 20 140 163 160 163 9 0 25 9 35 20 10 11 20 18 23 16 4 -5 14 3 47 32 7 6 16 12 18 12 3 0 22 8 43 17 22 9 42 16 47 15 4 -1 7 3 7 8 0 6 5 10 11 10 7 0 9 -76 7 -237z" fill="blue" />
                        <path d="M951 917 c-8 -10 -7 -14 2 -14 8 0 14 6 14 14 0 7 -1 13 -2 13 -2 0 -8 -6 -14 -13z" fill="blue" />
                        <path d="M328 1055 c-2 -2 -1 -91 2 -197 l5 -195 34 -44 c51 -66 231 -188 279 -189 19 0 11 355 -9 390 -22 40 -70 89 -124 129 -49 37 -182 111 -187 106z m87 -61 c22 -10 54 -27 70 -39 17 -12 38 -24 48 -28 10 -4 16 -11 12 -16 -3 -5 4 -13 15 -16 18 -6 19 -9 8 -23 -10 -12 -10 -14 0 -8 14 9 38 -13 51 -46 13 -35 23 -240 15 -304 -7 -56 -20 -67 -48 -39 -8 8 -17 15 -20 15 -13 0 -144 92 -169 119 -47 51 -57 97 -57 267 0 144 1 154 18 145 9 -6 35 -18 57 -27z" fill="blue" />
                    </g>
                </svg>
            </Box>

            <Stack spacing={2} alignItems="center" flexGrow={1} justifyContent="center">
                {iconList.map(({ icon, label }, i) => (
                    <Tooltip title={label} placement="right" key={label}>
                        <IconButton
                            onClick={() => setActiveIndex(i)}
                            sx={{
                                color: i === activeIndex ? '#fff' : '#666',
                                backgroundColor: i === activeIndex ? '#007bff' : 'transparent',
                                '&:hover': {
                                    backgroundColor: i === activeIndex ? '#0062cc' : '#f5f5f5'
                                },
                                width: 40,
                                height: 40,
                                borderRadius: 2,
                                justifyContent: 'space-between'
                            }}
                        >
                            {icon}
                        </IconButton>
                    </Tooltip>
                ))}
            </Stack>

            <Stack spacing={1} alignItems="center">
                <Avatar
                    src="https://randomuser.me/api/portraits/men/75.jpg"
                    sx={{ width: 40, height: 40 }}
                />
                <IconButton>
                    <SettingsRounded />
                </IconButton>
            </Stack>
        </Box>
    );
};

export default React.memo(Sidebar);