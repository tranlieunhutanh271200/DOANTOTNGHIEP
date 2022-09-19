import { useRef } from "react";

function BlackBoardComponent() {
    const blackboardRef = useRef();
    return ( <div>
        This is blackboard
        <canvas ref={blackboardRef}></canvas>
    </div> );
}

export default BlackBoardComponent;