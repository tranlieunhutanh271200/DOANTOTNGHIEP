import './video-script.css'
import ReactPlayer from 'react-player'
import { useState } from 'react';
const VideoScriptComponent = ({ script, remove, save, isModifiable = false }) => {
    const [data, setData] = useState(script);
    return (
        <div className='d-flex flex-column justify-content-center align-center video-script'>
            <div className={isModifiable ? 'edit-mode' : ''}>
                {!isModifiable ? <h3>{script.videoScriptTitle}</h3> :
                    <>
                        <div className="form-group">
                            <label htmlFor="">Tiêu đề</label>
                            <input className='form-field' defaultValue={script.videoScriptTitle} onChange={(e) => setData({...data, videoScriptTitle: e.target.value})}></input>
                        </div>
                    </>}
                <ReactPlayer controls url={script.videoPath} />
                {!isModifiable ? <p>{script.videoScriptDescription}</p>
                    : <>
                        <div className="form-group">
                            <label htmlFor="">Mô tả</label>
                            <input className='form-field' defaultValue={script.videoScriptDescription} onChange={(e) => setData({...data, videoScriptDescription: e.target.value})}></input>
                        </div>
                    </>}
                {isModifiable && (<>
                    <div className="save">
                        <ion-icon
                            size="large"
                            onClick={() => save(data)}
                            name="cloud-upload-outline"
                        ></ion-icon>
                    </div>
                    <div className="remove">
                        <ion-icon
                            size="large"
                            onClick={() => remove(script)}
                            name="trash-bin-outline"
                        ></ion-icon>
                    </div>
                </>)}
            </div>
        </div>);
}

export default VideoScriptComponent;