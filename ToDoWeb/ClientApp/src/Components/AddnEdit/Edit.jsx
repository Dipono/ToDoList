import './Add.css';
import {AiFillCloseCircle,} from 'react-icons/ai';

function Edit(props) {
    return (props.triggerEdit) ? (

        <div className="popup">
            <div className="popup-inner">
                <button className="popup-btn" onClick={() => props.setTriggerEdit(false)}>< AiFillCloseCircle /></button>
                {props.children}
            </div>
        </div>
    ) : "";
}

export default Edit;