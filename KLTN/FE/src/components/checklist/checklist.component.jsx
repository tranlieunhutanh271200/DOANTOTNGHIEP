import { useEffect, useState } from 'react';
import './checklist.css';
const CheckListComponent = ({item = [], own = [], click, displayName}) => {
    const [data,setData] = useState({
        available: item,
        have: own
    })

    useEffect(() => {
        setData({
            available: item,
            have: own
        })
    },[item,own])
    return (  <ul className="list-group1 list-group-flush1 checkbox-wrapper">
    {data.available.map((i, index) =>
        <li className={`list-group-item1 ${data.have.findIndex(x => x.id === i.id) !== -1 ? 'active' : ''}`} key={i.id} onClick={() => click(i)}>
            <div className="select-item1">
                <label className="custom-control-label1">{i[displayName]}</label>
            </div>
        </li>
    )}
</ul> );
}

export default CheckListComponent;