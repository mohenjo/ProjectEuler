import os


def chk_triagnles(x1, y1, x2, y2, x3, y3):
    # 세 점 P1(x1, y1), P2(x2, y2), P3(x3, y3)가 삼각형을 이루고 있을 때
    # 임의의 점 P(a, b)가 이 삼각형의 내부에 포함되는지 알아보려면
    # P1-P2를 지나는 직선의 함수 f12 = 0에 대해 f12(P3) 및 f12(P)가 같은 방향에, 즉 f12(P3) * f12(P) >=0
    # P2-P3를 지나는 직선의 함수 f23 = 0에 대해 f23(P1) 및 f23(P)가 같은 방향에, 즉 f23(P1) * f23(P) >= 0
    # P3-P1를 지나는 직선의 함수 f31 = 0에 대해 f31(P2) 및 f31(P)가 같은 방향에, 즉 f31(P2) * f31(P) >= 0
    # 을 모두 만족해야 한다.
    def line_eq1(x, y): return (y2 - y1) * (x - x1) - (x2 - x1) * (y - y1)
    def line_eq2(x, y): return (y3 - y2) * (x - x2) - (x3 - x2) * (y - y2)
    def line_eq3(x, y): return (y1 - y3) * (x - x3) - (x1 - x3) * (y - y3)
    check1 = line_eq1(x3, y3) * line_eq1(0, 0) >= 0
    check2 = line_eq2(x1, y1) * line_eq2(0, 0) >= 0
    check3 = line_eq3(x2, y2) * line_eq3(0, 0) >= 0
    return check1 and check2 and check3


def main():
    with open(os.getcwd() + os.sep + r"p102_triangles.txt") as f:
        lines = f.read()
    count = 0
    for line in lines.split():
        args = map(float, line.split(","))
        if chk_triagnles(*args):
            count += 1
    print(count)  # 228


if __name__ == "__main__":
    main()
