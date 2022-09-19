import {Link} from 'react-router-dom'
const NotfoundPage = () => {
  return (
    <div className="auth">
      <div className="authBox">
        <div className="not-found-page">
            <h1>Bạn không có quyền truy cập trang này, vui lòng liên hệ admin để được hỗ trợ</h1>
            <Link to={"/"}>Về trang chủ</Link>
        </div>
      </div>
    </div>
  );
};

export default NotfoundPage;
