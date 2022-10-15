using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryText
{

    #region Main History text

    public const string ZERO = "�����. �����������!";
    public const string ONE = "������, ����������� � ������ ������������ �����";
    public const string TWO = "������ �� ��������� � �������������";
    public const string THREE = "� ������ ������� ��� ����� � ���� ���������";
    public const string FOUR = "������� �������� ���� ������";
    public const string FIVE = "�� ����� �����";
    public const string SIX = "���� ������ ����������� ������, ����, � ������";
    public const string SEVEN = "�� ��� ����� ��� �� ��� ���������� ������ � ����� ���";
    public const string EIGHT = "��...";
    public const string NINE = "��������� � ����������";
    public const string TEN = "� ������ �����, ���������� ���� �������";

    #endregion

    #region Beginning meeting Orsic and Player

    public const string ORSIC_START_MEET = "������ �����";

    public const string ORSIC_MEET_SNEIL_1 = "������ �����";
    public const string ORSIC_MEET_SNEIL_2 = "�� ��� ���� ��� ���� ��������...";
    public const string ORSIC_MEET_SNEIL_3 = "�������, �� ������, � �� ���� �����������?";
    public const string ORSIC_MEET_SNEIL_4 = "�����, �����. �� ��������, ������� ���� ��� �������� ���������.";
    public const string ORSIC_MEET_SNEIL_5 = "� ���� ������ �����. �� �� ������ ���������, �� ����� �����!!!";
    public const string ORSIC_MEET_SNEIL_6 = "����� ����� �� ����� �������";
    public const string ORSIC_MEET_SNEIL_7 = "��.. ���, ��� ���������� � ��� ����, ����������� ������ ��� ������� � ���� �������. ����������?";
    public const string ORSIC_MEET_SNEIL_8 = "����� ���� ���� ����, ������ �������� � � ���, � ������";




    public const string PLAYER_START_MEET = "������ �����";

    public const string PLAYER_MEET_SNEIL_1 = "������ �����, ���� ����� ������?";
    public const string PLAYER_MEET_SNEIL_2 = "��� ���! � �� ������� �� ��� � ��� ������� ��� � ��������?";
    public const string PLAYER_MEET_SNEIL_3 = "��, ���. �� �� ������. �� ���� �� ������, �� ����...";
    public const string PLAYER_MEET_SNEIL_4 = "�� ������ ������� ��� �� ���������?";
    public const string PLAYER_MEET_SNEIL_5 = "���!!!";
    public const string PLAYER_MEET_SNEIL_6 = "��� ����� ���... �������� �� � � �������?";
    public const string PLAYER_MEET_SNEIL_7 = "�������";


    #endregion


    #region end Sneil Level meeting Orsic and Player

    

    public const string PLAYER_MEET_SNEIL_END_1 = "������ �����";
    public const string PLAYER_MEET_SNEIL_END_2 = "�������, � �� �� ��� ����������?";
    public const string PLAYER_MEET_SNEIL_END_3 = "� ��, �� � �� ��� �����...";
    public const string PLAYER_MEET_SNEIL_END_4 = "����� �� ������ ����� �����, ��� � �������.";
    public const string PLAYER_MEET_SNEIL_END_5 = "���� ��� � ����, ����� �� ��� ������ ������� �� ���������";
    public const string PLAYER_MEET_SNEIL_END_6 = "�����, ��� ���������? � �� ���� ���, ���-�� �� ���.";
    public const string PLAYER_MEET_SNEIL_END_7 = "� �� ����������, ��� ��� ����";
    public const string PLAYER_MEET_SNEIL_END_8 = "�� ��";
    public const string PLAYER_MEET_SNEIL_END_9 = "�� ����, �����";
    public const string PLAYER_MEET_SNEIL_END_10 = "��� ��� ������?";
    public const string PLAYER_MEET_SNEIL_END_11 = "���? ��� �� ��� �������?";
    public const string PLAYER_MEET_SNEIL_END_12 = "������!?!";
    public const string PLAYER_MEET_SNEIL_END_13 = "��� �� ������ �����? ���� ����� �����������! � �����.";
    public const string PLAYER_MEET_SNEIL_END_14 = "� �����, �����. �� �������� ���������� � ������� �������!";
    public const string PLAYER_MEET_SNEIL_END_15 = "�� ������ ������, ��� ��� ��� ������ � ������ �� ������, �����.";
    public const string PLAYER_MEET_SNEIL_END_16 = "���� �� ��������";
    public const string PLAYER_MEET_SNEIL_END_17 = "������� �����, ��� �� �� ������";
    public const string PLAYER_MEET_SNEIL_END_18 = "����� ����, �����. �������. ���������, ��� ��� � ���� ����� ����!";
    public const string PLAYER_MEET_SNEIL_END_19 = "������� �����, � ���������";


    public const string ORSIC_MEET_SNEIL_END_1 = "������ �����. �� ��� ���, ���� �������?";
    public const string ORSIC_MEET_SNEIL_END_2 = "���, ��� ��.. ������ ���� ������� ����� ��������";
    public const string ORSIC_MEET_SNEIL_END_3 = "� �������, �� ������� ��� ���� ����� �����?";
    public const string ORSIC_MEET_SNEIL_END_4 = "�� ��, �� ��...";
    public const string ORSIC_MEET_SNEIL_END_5 = "����� ���� ...";
    public const string ORSIC_MEET_SNEIL_END_6 = "��� ����� ����, �����";
    public const string ORSIC_MEET_SNEIL_END_7 = "�� �� ����� ���, � ������?";
    public const string ORSIC_MEET_SNEIL_END_8 = "��� ��� ���...";
    public const string ORSIC_MEET_SNEIL_END_9 = "� �����, ������ ���� ����!";
    public const string ORSIC_MEET_SNEIL_END_10 = "������ ���.";
    public const string ORSIC_MEET_SNEIL_END_11 = "������, �������!!! ������ �����.";
    public const string ORSIC_MEET_SNEIL_END_12 = "���� ��� ���� � ������ � ������������������. � ������� ���, �������� ���, � ������� ����";
    public const string ORSIC_MEET_SNEIL_END_13 = "����!!! ������� �� ����. ���������� ��.";
    public const string ORSIC_MEET_SNEIL_END_14 = "��� ���� �� ����� � ���������! � �������� �������� �������";
    public const string ORSIC_MEET_SNEIL_END_15 = "� �� � �� �����! ������ ����.";
    public const string ORSIC_MEET_SNEIL_END_16 = "� ���� ���� �����. ��� �� ������� �������� ���� ���������� � ����� ������� ������� ��� �������";
    public const string ORSIC_MEET_SNEIL_END_17 = "������ ����� �������� ������� �����������, �����. ���� ����� �����, ����� �������� � ������";
    public const string ORSIC_MEET_SNEIL_END_18 = "� ������ ���� �����! � ������ ����.";
    #endregion

}
