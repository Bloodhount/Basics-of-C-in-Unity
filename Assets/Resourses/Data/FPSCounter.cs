using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FPSCounter : MonoBehaviour
{
    [SerializeField] private int _numberFramesToCalculate = 60;
    private int[] _framesBuffer;
    private int _framesBufferIndex;
    public int FPS { get; private set; }
    public int HighFPS { get; private set; }
    public int LowFPS { get; private set; }

    void Update()
    {
        if (_framesBuffer == null || _numberFramesToCalculate != _framesBuffer.Length)
        {
            InstantiateBuffer();
        }
        CalculateFPS();
        UpdateBuffer();
    }
    private void InstantiateBuffer()
    {
        if (_numberFramesToCalculate <= 0)
        {
            _numberFramesToCalculate = 1;
        }
        _framesBuffer = new int[_numberFramesToCalculate];
        _framesBufferIndex = 0;
    }
    private void CalculateFPS()
    {
        int sum = 0;
        int lowest = int.MaxValue;
        int highest = 0;
        for (int i = 0; i < _numberFramesToCalculate; i++)
        {
            int fps = _framesBuffer[i];
            sum += fps;
            if (fps > highest)
            {
                highest = fps;
            }
            if (fps < lowest)
            {
                lowest = fps;
            }
        }
        HighFPS = highest;
        LowFPS = lowest;
        FPS = sum / _numberFramesToCalculate;
    }
    private void UpdateBuffer()
    {
        _framesBuffer[_framesBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (_framesBufferIndex >= _numberFramesToCalculate)
        {
            _framesBufferIndex = 0;
        }
    }
}
