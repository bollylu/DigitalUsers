﻿namespace digiusersweb;

public interface IBusService<T> {
  event Action<string, T> OnMessage;
  void SendMessage(string source, T message);
}

