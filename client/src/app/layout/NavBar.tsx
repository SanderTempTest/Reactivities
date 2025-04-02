import { Box, AppBar, Toolbar, Typography, Container, MenuItem, LinearProgress } from "@mui/material";
import { Group } from "@mui/icons-material";
import { NavLink } from "react-router";
import MenutItemLink from "../shared/components/MenutItemLink";
import { useStore } from "../../lib/hooks/useStore";
import { Observer } from "mobx-react-lite";


export default function NavBar() {
    const { uiStore } = useStore();

    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar
                position="static"
                sx={{
                    backgroundImage: 'linear-gradient(123deg, #182a73 0%, #218aae 69%, #20a7ac 89%)',
                    position: 'relative'
                }}>
                <Container maxWidth='xl'>
                    <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
                        <Box>
                            <MenuItem component={NavLink} to='/' sx={{ display: 'flex', gap: 2 }}>
                                <Group fontSize="large" />
                                <Typography variant="h4" fontWeight='bold'>Reactivities</Typography>
                            </MenuItem>
                        </Box>
                        <Box sx={{ display: 'flex' }}>
                            <MenutItemLink to='/activities'>
                                Activities
                            </MenutItemLink>
                            <MenutItemLink to='/createActivity'>
                                Create activity
                            </MenutItemLink>
                            <MenutItemLink to='/counter'>
                                Counter
                            </MenutItemLink>
                        </Box>
                        <MenuItem>
                            User menu
                        </MenuItem>
                    </Toolbar>
                </Container>
                <Observer>
                    {() => uiStore.isloading ? (
                        <LinearProgress
                            sx={{
                                position: 'absolute',
                                bottom: 0,
                                left: 0,
                                right: 0,
                                height: 4
                            }}
                            color="secondary" />
                    ) : null}
                </Observer>
            </AppBar>
        </Box>
    );
}