import { Outlet } from "react-router-dom";
import { Header } from "./App/layout/Header";
import { HomePage } from "./App/layout/HomePage";
import { NavBar } from "./App/layout/NavBar";

function App() {



    return (
        <>
            {window.location.pathname === "/" ? <HomePage /> : (
                <>
                    <Header>
                        <NavBar />
                    </Header>
                    <Outlet />
                </>
            )}
        </>
    );
}

export default App;
