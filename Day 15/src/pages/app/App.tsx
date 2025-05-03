import { Box } from '@mui/material';
import Sidebar from '../../components/sidebar';
import Header from '../../components/header';
import UserTable2 from '../../components/userTable';
import { UserProvider } from '../../components/contextUser';

function App() {
    return (
        <>
            <Box
                sx={{
                display: 'grid',
                gridTemplateColumns: { xs: '1fr', md: '100px 1fr' },
                height: '100vh',
                overflow: 'hidden',
                }}>
                <Box
                    sx={{
                        display: { xs: 'none', md: 'block' }, 
                    }}
                    >
                    <Sidebar />
                </Box>

                <Box
                    sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        overflow: 'auto',
                        width: '100%', 
                    }}>
                    <Box sx={{ flexGrow: 1, padding: 1 }}>
                        <Header />
                    </Box>
                    
                    <UserProvider>
                        <Box sx={{ flexGrow: 1, padding: 1 }}>
                            <UserTable2 />
                        </Box>
                    </UserProvider>
                </Box>
            </Box>
        </>
    );
}

export default App;