import "./setting.css";
import Columns from "react-columns";
import { useSelector } from "react-redux";
import { ROLE } from "../../consts/role.const";
import { useEffect, useState } from "react";
import axiosClient from "../../global/axios/axiosClient";
const SettingPage = () => {
  const tabs = {
    ACCOUNT: "account",
    PASSWORD: "password",
    NOTIFICATION: "notification",
  };
  const { account } = useSelector((x) => x.auth);
  const { data } = useSelector((x) => x.auth);
  const [tab, setTab] = useState(tabs.ACCOUNT);
  const [notifications, setNotifications] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      const notification = await axiosClient.get(
        `/api/crm/notification?accountId=${account.id}`
      );
      setNotifications(notification);
    };
    fetchData();
  });
  return (
    <>
      <section className="py-5 my-5">
        <div className="container">
          <h2 className="mb-1">Cài đặt tài khoản</h2>
          <div className="bg-white shadow rounded-lg d-block d-sm-flex bg-glass">
            <div className="profile-tab-nav border-right">
              <div className="p-4">
                <div
                  className="img-circle text-center mb-3"
                  style={{ width: "200px" }}
                >
                  <img
                    style={{
                      objectFit: "cover",
                      height: "100%",
                      width: "100%",
                    }}
                    src={`${
                      account.gender === 1
                        ? "/img/male-default-avatar.png"
                        : "/img/Untitled design1.png"
                    }`}
                    alt="avatar"
                    className="shadow"
                  />
                </div>
                <h4 className="text-center">
                  {account.role === ROLE.STUDENT
                    ? data.student.fullName
                    : data.teacher.fullName}
                </h4>
              </div>
              <div
                className="nav flex-column nav-pills w-100"
                id="v-pills-tab"
                role="tablist"
                aria-orientation="vertical"
              >
                <button
                  className={`nav-link ${tab === tabs.ACCOUNT && "active"}`}
                  id="account-tab"
                  data-toggle="pill"
                  href="#account"
                  role="tab"
                  aria-controls="account"
                  aria-selected="true"
                  onClick={() => setTab(tabs.ACCOUNT)}
                >
                  <i className="fa fa-home text-center mr-1"></i>
                  Thông tin
                </button>
                <button
                  className={`nav-link ${tab === tabs.PASSWORD && "active"}`}
                  id="password-tab"
                  data-toggle="pill"
                  href="#password"
                  role="tab"
                  aria-controls="password"
                  aria-selected="false"
                  onClick={() => setTab(tabs.PASSWORD)}
                >
                  <i className="fa fa-key text-center mr-1"></i>
                  Mật khẩu
                </button>
                <button
                  className={`nav-link ${tab === tabs.NOTIFICATION && "active"}`}
                  id="notification-tab"
                  data-toggle="pill"
                  href="#notification"
                  role="tab"
                  aria-controls="notification"
                  aria-selected="false"
                  onClick={() => setTab(tabs.NOTIFICATION)}
                >
                  <i className="fa fa-bell text-center mr-1"></i>
                  Thông báo
                </button>
              </div>
            </div>
            <div className="tab-content p-4 p-md-5" id="v-pills-tabContent">
              {tab === tabs.ACCOUNT && (
                <div
                  className="tab-pane fade show active"
                  id="account"
                  role="tabpanel"
                  aria-labelledby="account-tab"
                >
                  <h3 className="mb-4">Thông tin tài khoản</h3>
                  <div className="row">
                    <div className="form-group">
                      <label>Tài khoản</label>
                      <p className="form-field">{account.username}</p>
                    </div>
                    <div className="form-group">
                      <label>Domain</label>
                      <p className="form-field">{account.domain.abbreviation}</p>
                    </div>
                    <div className="form-group">
                      <label>Trường</label>
                      <p className="form-field">{account.domain.schoolName}</p>
                    </div>
                  </div>
                </div>
              )}
              {tab === tabs.PASSWORD && (
                <>
                  {" "}
                  <div
                    className="tab-pane fade show active"
                    id="password"
                    role="tabpanel"
                    aria-labelledby="password-tab"
                  >
                    <h3 className="mb-4">Đổi mật khẩu</h3>
                    <div className="row">
                      <div className="col-md-6">
                        <div className="form-group">
                          <label>Mật khẩu cũ</label>
                          <input type="password" className="form-control" />
                        </div>
                      </div>
                    </div>
                    <div className="row">
                      <div className="col-md-6">
                        <div className="form-group">
                          <label>Mật khẩu mới</label>
                          <input type="password" className="form-control" />
                        </div>
                      </div>
                      <div className="col-md-6">
                        <div className="form-group">
                          <label>Xác nhận mật khẩu</label>
                          <input type="password" className="form-control" />
                        </div>
                      </div>
                    </div>
                    <div className="d-flex">
                      <button className="btn btn-primary">Lưu</button>
                    </div>
                  </div>
                </>
              )}
              {tab === tabs.NOTIFICATION && (
                <div
                  className="tab-pane fade show active"
                  id="notification"
                  role="tabpanel"
                  aria-labelledby="notification-tab"
                >
                  <h3 className="mb-4">Thông báo</h3>
                  <ul className="list-group notify-group">
                    {notifications.map((notify, idx) => (
                      <li key={idx} className="list-group-item">
                        {notify.content}
                      </li>
                    ))}
                  </ul>
                </div>
              )}
            </div>
          </div>
        </div>
      </section>
    </>
  );
};

export default SettingPage;
