import './tag.css'
export const TagType = {
    WARNING: 'tag-warning',
    INFOR: 'tag-info',
    DANGER: 'tag-danger',
    SUCCESS: 'tag-success',
    PRIMARY: 'tag-primary'
}
const TagComponent = ({name, type = TagType.INFOR, isFull, action}) => {
    return ( <div className={`${type} ${isFull ? 'full' : ''}`}>
        {name}
    </div> );
}

export default TagComponent;