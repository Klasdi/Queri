INSERT INTO  public."Surveys" ("Name", "Description", "CreateTime", "UpdateTime", "IsActive")
VALUES 
('������ ��������', '����� ��� ����� ������ ��������', '2023-10-01 10:00:00', '2023-10-05 15:00:00', true),
('����������������� �����������', '���������� ����� ��� �����������', '2023-10-02 09:00:00', NULL, true);

INSERT INTO public."Questions" ("Name", "TypeAnswer", "SerialNumber", "SurveyId")
VALUES 
('��������� �� �������������?', 1, 1, 1),
('��� �� ����� ��������?', 2, 2, 1),
('��� �� ���������� ������ ������������?', 1, 1, 2),
('����� ������ �� ������?', 2, 2, 2);

INSERT INTO public."Answers" ("Name", "SerialNumber", "QuestionId")
VALUES 
('����� �������', 1, 1),
('�������', 2, 1),
('����������', 3, 1),
('�� �������', 4, 1),
('����� �� �������', 5, 1),
('������ ������������ ��������', 1, 2),
('����� ������� ��������', 2, 2),
('�������', 1, 3),
('������', 2, 3),
('������', 3, 3),
('�����', 4, 3),
('����������� ���������', 1, 4),
('������ ������', 2, 4),
('��������� ������', 3, 4);

INSERT INTO public."Interviews" ("UserId", "StartTime", "FinishTime", "Status", "SurveyId")
VALUES 
(101, '2023-10-10 14:00:00', '2023-10-10 14:30:00', 1, 1),
(102, '2023-10-11 10:00:00', '2023-10-11 10:45:00', 1, 2);

INSERT INTO public."Results" ("InterviewId", "QuestionId", "AnswerId", "AnswerTime")
VALUES 
(1, 1, 2, '2023-10-10 14:05:00'),
(1, 2, 6, '2023-10-10 14:10:00'),
(2, 3, 8, '2023-10-11 10:10:00'),
(2, 4, 12, '2023-10-11 10:20:00');
