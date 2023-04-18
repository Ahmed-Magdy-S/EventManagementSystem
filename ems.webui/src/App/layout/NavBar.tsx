import { Button, Container, Nav, Navbar, Image } from "react-bootstrap";
import { Link, NavLink } from "react-router-dom";

function NavBar() {

    return (
        <Navbar bg="dark" variant="dark">
            <Container>
                <Nav>
                    <Navbar.Brand href="/events">
                        <Image src="/images/logo.png" alt="Brand-Logo" className="w-25" />
                        Events
                    </Navbar.Brand>
                    <NavLink className="btn btn-primary" to="/create">Create Event</NavLink>
                </Nav>
            </Container>
        </Navbar>
    )
}


export { NavBar };