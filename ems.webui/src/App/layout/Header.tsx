import { PropsWithChildren } from "react"

function Header(props: PropsWithChildren){


    return (
        <header>
            {props.children}
        </header>
    )
}

export { Header }